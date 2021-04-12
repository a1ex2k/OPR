using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace OPR
{
    static internal class Plotting
    {
        const int x1stepcount = 500;
        const int x2stepcount = 500;
        const int steps = 10;

        public static List<Series> Isolines(Optimize.BasicData input)
        {
            double x1step = input.Bounds.X1Interval / (double)x1stepcount;
            double x2step = input.Bounds.X2Interval / (double)x2stepcount;
            var list = new List<Point>();
            var list_good = new List<Point>();
            for (int i = 0; i < x1stepcount;  i++)
            {
                double x1 = input.Bounds.X1Lower + x1step * i;
                for (int j = 0; j < x2stepcount; j++)
                {
                    double x2 = input.Bounds.X2Lower + x2step * j;
                    double y = input.Function.Calc(x1, x2);
                    list.Add(new Point(x1, x2, y));
                    if (input.CheckRestrictions(x1, x2)) list_good.Add(new Point(x1, x2, y));
                }
            };

            double min = list.AsParallel().Min(p => p.Y);
            double max = list.AsParallel().Max(p => p.Y);
            double step = (max - min) / steps;
            var ss = new List<Series>();
            ss.Add(PlacePoints(list_good, $"Restrictions", Color.LightGreen, 1));
            System.Threading.Tasks.Parallel.For(1, steps, (i) =>
            {
                int ey = 1 + MathExpr.GetPrecision(min + i * step);
                double y = MathExpr.Round(min + i * step, ey);
                double delta_y = Math.Pow(step, -ey) / 1.5;
                var list2 = list.Where(p => p.Y > y - delta_y && p.Y < y + delta_y);
                var s = PlacePoints(list2, $"Iso{i}", SystemColors.Highlight, 1);
                int index = new Random().Next(s.Points.Count / 3, s.Points.Count / 3 * 2);
                if (index > 0) s.Points[index].Label = y.ToString();
                ss.Add(s);
            });
            return ss;
        }
        public static Series PlacePoints(IEnumerable<Point> points, string label, Color color, int size = 10, MarkerStyle marker = MarkerStyle.Circle, SeriesChartType type = SeriesChartType.Point)
        {
            Series s = new Series(label);
            s.Points.DataBindXY(points.Select(g => g.X1).ToList(), points.Select(g => g.X2).ToList());
            s.ChartType = type;
            s.Color = Color.Black;
            s.MarkerColor = color;
            s.MarkerSize = size;
            s.MarkerBorderWidth = 0;
            s.MarkerStyle = marker;
            return s;
        }

        public static Series PlacePoint(Point point, Color color, int size = 8, MarkerStyle marker = MarkerStyle.Circle)
        {
            Series s = new Series($"Point{point.Y}-{point.X1}-{point.X2}");
            s.Points.AddXY(point.X1, point.X2);
            s.ChartType = SeriesChartType.Point;
            s.MarkerColor = color;
            s.MarkerSize = size;
            s.MarkerBorderWidth = 2;
            s.MarkerStyle = marker;
            s.Label = point.Y.ToString();
            return s;
        }



    }
}
