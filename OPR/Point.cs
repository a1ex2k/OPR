namespace OPR
{
    class Point
    {
        public double X1 { get; }
        public double X2 { get; }
        public double Y { get; }
        public Point(double x1, double x2, double y)
        {
            this.X1 = x1; this.X2 = x2; this.Y = y;
        }
        public override string ToString()
        {
            return $"x\u2081 = {X1}\r\nx\u2082 = {X2}\r\nf(x\u2081, x\u2082) = {Y}";
        }
    }
}
