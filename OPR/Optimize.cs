using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace OPR
{
    internal abstract class Optimize
    {
        public class BasicData
        {
            public BasicData(MathExpr function, Criteria criteria, MathExpr[] restrictions, VarBounds bounds)
            {
                this.Function = function;
                this.Restrictions = restrictions;
                this.OptCriteria = criteria;
                this.Bounds = bounds;
            }
            public MathExpr Function { get; }
            public MathExpr[] Restrictions { get; }
            public Criteria OptCriteria { get; }
            public class VarBounds
            {
                public VarBounds(double x1Bound1, double x1Bound2, double x2Bound1, double x2Bound2)
                {
                    X1Lower = Math.Min(x1Bound1, x1Bound2);
                    X2Lower = Math.Min(x2Bound1, x2Bound2);
                    X1Upper = Math.Max(x1Bound1, x1Bound2);
                    X2Upper = Math.Max(x2Bound1, x2Bound2);
                    X1Interval = X1Upper - X1Lower;
                    X2Interval = X2Upper - X2Lower;
                }
                public double X1Lower { get; }
                public double X1Upper { get; }
                public double X2Lower { get; }
                public double X2Upper { get; }
                public double X2Interval { get; }
                public double X1Interval { get; }
                public bool IsInRange(double x1, double x2)
                {
                    if (x1 >= X1Lower && x1 <= X1Upper && x2 >= X2Lower && x2 <= X2Upper) return true;
                    return false;
                }
                public override string ToString()
                {
                    return $"[{X1Lower},{X1Upper}; {X2Lower},{X2Upper}]";
                }
            }

            public enum Criteria : int
            {
                Minimum = -1, Maximum = 1,
            }
            public VarBounds Bounds { get; }
            public bool CheckRestrictions(double x1, double x2)
            {
                bool match = true;
                foreach (var expr in Restrictions)
                    if (expr.Calc(x1, x2) != MathExpr.LogicalTrue)
                    {
                        match = false; break;
                    }
                return match;
            }

        }
        public BasicData Data { get; }
        public Point Result { get; protected set; }
        public uint Iterations { get; protected set; }
        public double Duration { get; protected set; }
        public Optimize(BasicData data)
        {
            Data = data;
        }
        public abstract void RunOptimization();
    }
    internal class GridBruteForce : Optimize
    {
        public double StepSize { get; }
        public double[,] Matrix { get; private set; }
        public double[] X1Array { get; private set; }
        public double[] X2Array { get; private set; }
        private readonly int e;
        public GridBruteForce(BasicData input, double step) : base(input)
        {
            if (step <= 0) throw new ArgumentException();
            this.StepSize = Math.Abs(step);
            this.e = 1 + MathExpr.GetPrecision(StepSize);
        }
        public override void RunOptimization()
        {
            Stopwatch stw = new Stopwatch();
            stw.Start();

            int x1Count = 1 + (int)(Data.Bounds.X1Interval / StepSize);
            int x2Count = 1 + (int)(Data.Bounds.X2Interval / StepSize);
            Iterations = (uint)(x1Count * x2Count);
            X1Array = new double[x1Count];
            X2Array = new double[x2Count];
            for (int x1Step = 0; x1Step < x1Count; x1Step++)
                X1Array[x1Step] = MathExpr.Round(Data.Bounds.X1Lower + StepSize * x1Step, e);
            for (int x2Step = 0; x2Step < x2Count; x2Step++)
                X2Array[x2Step] = MathExpr.Round(Data.Bounds.X2Lower + StepSize * x2Step, e);

            Matrix = new double[X1Array.Length, X2Array.Length];
            int opt_i = 0; int opt_j = 0;
            for (int i = 0; i < Matrix.GetLength(0); i++)
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Matrix[i, j] = Data.Function.Calc(X1Array[i], X2Array[j]);
                    if (Data.CheckRestrictions(X1Array[i], X2Array[j]))
                    {
                        if ((Data.OptCriteria == BasicData.Criteria.Minimum && Matrix[i, j] < Matrix[opt_i, opt_j]) ||
                        (Data.OptCriteria == BasicData.Criteria.Maximum && Matrix[i, j] > Matrix[opt_i, opt_j]))
                        { opt_i = i; opt_j = j; }
                    }
                }
            stw.Stop();
            Duration = stw.Elapsed.TotalMilliseconds;
            Result = new Point(X1Array[opt_i], X2Array[opt_j], Matrix[opt_i, opt_j]);
        }
    }

    internal class MonteCarlo : Optimize
    {
        public List<Point> Points { get; private set; }
        public MonteCarlo(BasicData input, uint iterCount) : base(input)
        {
            if (iterCount == 0) throw new ArgumentException();
            Iterations = iterCount;
        }
        public override void RunOptimization()
        {
            Stopwatch stw = new Stopwatch();
            stw.Start();
            Points = new List<Point>();
            double _y = 0, y, x1, x2;
            if (Data.OptCriteria == BasicData.Criteria.Minimum) _y = double.MaxValue;
            if (Data.OptCriteria == BasicData.Criteria.Maximum) _y = double.MinValue;
            Point best = null;
            var rnd = new Random();
            for (int iter = 0; iter < Iterations; iter++)
            {
                x1 = Data.Bounds.X1Lower + Data.Bounds.X1Interval * rnd.NextDouble();
                x2 = Data.Bounds.X2Lower + Data.Bounds.X2Interval * rnd.NextDouble();
                if (Data.CheckRestrictions(x1, x2))
                {
                    y = Data.Function.Calc(x1, x2);
                    if ((Data.OptCriteria == BasicData.Criteria.Minimum && y < _y) ||
                        (Data.OptCriteria == BasicData.Criteria.Maximum && y > _y))
                    {
                        best = new Point(x1, x2, y); _y = y;
                    }
                    Points.Add(new Point(x1, x2, y));
                }
            }
            if (best == null) throw new OperationCanceledException();
            stw.Stop();
            Duration = stw.Elapsed.TotalMilliseconds;
            Result = best;
        }
    }

    internal class HookeJeeves : Optimize
    {
        public double Epsylon { get; private set; }
        double step1, step2;
        public List<Point> Points { get; private set; }
        public Point StartPoint { get; private set; } = null;
        const int iterForRnd = 500;
        const double div = 2;

        public HookeJeeves(BasicData input, double epsylon, double step1, double step2, Point startPoint = null) : base(input)
        {
            if (epsylon <= 0 || step1 <= 0 || step1 <= 0 || step1 <= epsylon || step2 <= epsylon) throw new ArgumentException();
            StartPoint = startPoint;
            Epsylon = epsylon;
            this.step1 = step1;
            this.step2 = step2;
        }
        private bool IsBetter(double yCurrent, double yPrev)
        {
            if ((Data.OptCriteria == BasicData.Criteria.Minimum && yCurrent < yPrev) ||
               (Data.OptCriteria == BasicData.Criteria.Maximum && yCurrent > yPrev))
                return true;
            return false;
        }

        private void CheckStartPoint()
        {
            if (StartPoint == null || !Data.CheckRestrictions(StartPoint.X1, StartPoint.X2))
            {
                var rnd = new Random();
                for (int iter = 0; iter < iterForRnd; iter++)
                {
                    double x1 = Data.Bounds.X1Lower + Data.Bounds.X1Interval * rnd.NextDouble();
                    double x2 = Data.Bounds.X2Lower + Data.Bounds.X2Interval * rnd.NextDouble();
                    double y;
                    if (Data.CheckRestrictions(x1, x2))
                    {
                        y = Data.Function.Calc(x1, x2); StartPoint = new Point(x1, x2, y); break;
                    }
                }
            }
            if (StartPoint == null) throw new ArgumentOutOfRangeException();
        }

        public override void RunOptimization()
        {
            Stopwatch stw = new Stopwatch();
            stw.Start();

            CheckStartPoint();
            Points = new List<Point>();
            Points.Add(StartPoint);
            uint iter = 0;
            Point prevPoint = StartPoint;
            int e = 3 + MathExpr.GetPrecision(Epsylon);
            while (step1 > Epsylon || step2 > Epsylon)
            {
                iter++;
                bool x1_success = false;
                bool x2_success = false;
                double pr_x2 = MathExpr.Round(prevPoint.X2, e);
                double x1Upper = MathExpr.Round(prevPoint.X1 + step1, e);
                if (Data.CheckRestrictions(x1Upper, pr_x2))
                {
                    double y = Data.Function.Calc(x1Upper, pr_x2);
                    if (IsBetter(y, prevPoint.Y))
                    {
                        prevPoint = new Point(x1Upper, pr_x2, y);
                        x1_success = true;
                    }
                }
                double x1Lower = MathExpr.Round(prevPoint.X1 - step1, e);
                if (Data.CheckRestrictions(x1Lower, pr_x2))
                {
                    double y = Data.Function.Calc(x1Lower, pr_x2);
                    if (IsBetter(y, prevPoint.Y))
                    {
                        prevPoint = new Point(x1Lower, pr_x2, y);
                        x1_success = true;
                    }
                }
                if (!x1_success)
                {
                    step1 /= div;
                    double x2Upper = MathExpr.Round(prevPoint.X2 + step2, e);
                    double pr_x1 = MathExpr.Round(prevPoint.X1, e); 
                    if (Data.CheckRestrictions(pr_x1, x2Upper))
                    {
                        double y = Data.Function.Calc(pr_x1, x2Upper);
                        if (IsBetter(y, prevPoint.Y))
                        {
                            prevPoint = new Point(pr_x1, x2Upper, y);
                            x2_success = true;
                        }
                    }
                    double x2Lower = MathExpr.Round(prevPoint.X2 - step2, e);
                    if (Data.CheckRestrictions(pr_x1, x2Lower))
                    {
                        double y = Data.Function.Calc(prevPoint.X1, x2Lower);
                        if (IsBetter(y, prevPoint.Y))
                        {
                            prevPoint = new Point(pr_x1, x2Lower, y);
                            x2_success = true;
                        }
                    }
                }
                Points.Add(prevPoint);
                if (x1_success || x2_success) continue;
                else
                {
                    step1 /= div;
                    step2 /= div;
                }
            }
            stw.Stop();
            Duration = stw.Elapsed.TotalMilliseconds;
            Result = Points.Last();
            Iterations = iter;
        }
    }

}
