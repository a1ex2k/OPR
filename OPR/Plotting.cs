using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace OPR
{
    static internal class Plotting
    {
        const int x1stepcount = 500;
        const int x2stepcount = 500;
        const int steps = 7;
        public static List<Series> Isolines(Optimize.InputData data)
        {
            double x1step = data.Bounds.X1Interval / (double)x1stepcount;
            double x2step = data.Bounds.X2Interval / (double)x2stepcount;
            var list = new List<Point>();
            var list_good = new List<Point>();
            for (int i = 0; i < x1stepcount; i++)
            {
                double x1 = data.Bounds.X1Lower + x1step * i;
                for (int j = 0; j < x2stepcount; j++)
                {
                    double x2 = data.Bounds.X2Lower + x2step * j;
                    double y = data.Function.Calc(x1, x2);
                    list.Add(new Point(x1, x2, y));
                    if (data.CheckRestrictions(x1, x2)) list_good.Add(new Point(x1, x2, y));
                }
            }
            Series s_good = PlacePoints(list_good, $"Restrictions", Color.LightGreen, 1);
            double min = list.Min(p => p.Y);
            double max = list.Max(p => p.Y);
            double step = (max - min) / steps;
            var ss = new List<Series>();
            ss.Add(s_good);
            for (int i = 0; i < steps; i++)
            {
                double h = (i == 0) ? 0.3 : i;
                int ey = 1 + MathExpr.GetPrecision(min + h * step);
                double y = MathExpr.Round((min + h * step), ey);
                double delta_y = Math.Pow(step, -ey)/1.5;
                var list2 = list.Where(p => p.Y > y - delta_y && p.Y < y + delta_y);
                var s = PlacePoints(list2.ToList(), $"Iso{i}", SystemColors.Highlight, 2);
                int index = new Random().Next(s.Points.Count / 3, s.Points.Count / 3 * 2);
                if (index > 0) s.Points[index].Label = y.ToString();
                ss.Add(s);
            }
            return ss;
        }
        public static Series PlacePoints(List<Point> points, string label, Color color, int size = 10, MarkerStyle marker = MarkerStyle.Circle)
        {
            Series s = new Series(label);
            s.Points.DataBindXY(points.Select(g => g.X1).ToList(), points.Select(g => g.X2).ToList());
            s.ChartType = SeriesChartType.Point;
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
