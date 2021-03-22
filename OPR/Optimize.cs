using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace OPR
{
    internal abstract class Optimize
    {
        public class InputData
        {
            public InputData(MathExpr function, Criteria criteria, MathExpr[] restrictions, VarBounds bounds)
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
        public InputData Input { get; }
        public Point Result { get; protected set; }
        public uint Iterations { get; protected set; }
        public double Duration { get; protected set; }
        public Optimize(InputData data)
        {
            Input = data;
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
        public GridBruteForce(InputData input, double step) : base(input)
        {
            this.StepSize = Math.Abs(step);
            this.e = 1 + MathExpr.GetPrecision(StepSize);
        }
        public override void RunOptimization()
        {
            Stopwatch stw = new Stopwatch();
            stw.Start();

            int x1Count = 1 + (int)(Input.Bounds.X1Interval / StepSize);
            int x2Count = 1 + (int)(Input.Bounds.X2Interval / StepSize);
            Iterations = (uint)(x1Count * x2Count);
            X1Array = new double[x1Count];
            X2Array = new double[x2Count];
            for (int x1Step = 0; x1Step < x1Count; x1Step++)
                X1Array[x1Step] = MathExpr.Round(Input.Bounds.X1Lower + StepSize * x1Step, e);
            for (int x2Step = 0; x2Step < x2Count; x2Step++)
                X2Array[x2Step] = MathExpr.Round(Input.Bounds.X2Lower + StepSize * x2Step, e);

            Matrix = new double[X1Array.Length, X2Array.Length];
            int opt_i = 0; int opt_j = 0;
            for (int i = 0; i < Matrix.GetLength(0); i++)
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Matrix[i, j] = Input.Function.Calc(X1Array[i], X2Array[j]);
                    if (Input.CheckRestrictions(X1Array[i], X2Array[j]))
                    {
                        if ((Input.OptCriteria == InputData.Criteria.Minimum && Matrix[i, j] < Matrix[opt_i, opt_j]) ||
                        (Input.OptCriteria == InputData.Criteria.Maximum && Matrix[i, j] > Matrix[opt_i, opt_j]))
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
        public MonteCarlo(InputData input, uint iterCount) : base(input)
        {
            Iterations = iterCount;
        }
        public override void RunOptimization()
        {
            Stopwatch stw = new Stopwatch();
            stw.Start();
            Points = new List<Point>();
            double _y=0, y, x1, x2;
            if (Input.OptCriteria == InputData.Criteria.Minimum) _y = double.MaxValue;
            if (Input.OptCriteria == InputData.Criteria.Maximum) _y = double.MinValue;
            Point best = null;
            var rnd = new Random();
            for (int iter = 0; iter < Iterations; iter++)
            {
                x1 = Input.Bounds.X1Lower + Input.Bounds.X1Interval * rnd.NextDouble();
                x2 = Input.Bounds.X2Lower + Input.Bounds.X2Interval * rnd.NextDouble();
                if (Input.CheckRestrictions(x1, x2))
                {
                    y = Input.Function.Calc(x1, x2);
                    if ((Input.OptCriteria == InputData.Criteria.Minimum && y < _y) ||
                        (Input.OptCriteria == InputData.Criteria.Maximum && y > _y))
                    {
                        best = new Point(x1, x2, y);
                        _y = y;
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
}
