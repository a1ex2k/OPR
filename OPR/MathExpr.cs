using System;
using info.lundin.math;

namespace OPR
{
    internal class MathExpr
    {
        private readonly string expressionString;
        public double CurrentResult { get; private set; }
        private ExpressionParser parser;
        public const double LogicalTrue = 1.0;
        public MathExpr(string ExpressionString)
        {
            this.expressionString = ExpressionString;
            this.parser = new ExpressionParser();
            parser.Values.Add("x1", 1);
            parser.Values.Add("x2", 1);
        }
        public double Calc(double x1, double x2)
        {
            parser.Values["x1"].SetValue(x1);
            parser.Values["x2"].SetValue(x2);
            CurrentResult = parser.Parse(expressionString);
            return CurrentResult;
        }
        public static int GetPrecision(double step)
        {
            return (int)-Math.Ceiling(Math.Log10(Math.Abs(step)))+1;
        }
        public static double Round(double x, int e)
        {
            if (e >= 0) return Math.Round(x, e);
            else return Math.Round(x / Math.Pow(10, -e), 0) * Math.Pow(10, -e);
        }
        public static double Round(double x)
        {
            int e = GetPrecision(x);
            if (e >= 0) return Math.Round(x, e);
            else return Math.Round(x / Math.Pow(10, -e), 0) * Math.Pow(10, -e);
        }
        public override string ToString()
        {
            return expressionString;
        }
    }
}
