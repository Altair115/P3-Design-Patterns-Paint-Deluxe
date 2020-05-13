using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PaintApp4Scrubs.Classes.Shapes;

namespace PaintApp4Scrubs.Classes.Strategies
{
    public class TriangleStrategies : IStrategy
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public TriangleStrategies(double width, double height)
        {
            Height = height;
            Width = width;
        }
        public Geometry GetGeometry()
        {
            Point p1 = new Point(0.0d, 0.0d);
            Point p2 = new Point(this.Width, 0);
            Point p3 = new Point(this.Width / 2, this.Height);


            List<PathSegment> segments = new List<PathSegment>(3);
            segments.Add(new LineSegment(p1, true));
            segments.Add(new LineSegment(p2, true));
            segments.Add(new LineSegment(p3, true));

            List<PathFigure> figures = new List<PathFigure>(1);
            PathFigure pf = new PathFigure(p1, segments, true);
            figures.Add(pf);

            Geometry geometry = new PathGeometry(figures, FillRule.EvenOdd, null);

            return geometry;
        }
        public string GetString(BaseShape baseShape)
        {
            return $"Triangle {Canvas.GetLeft(baseShape)} {Canvas.GetTop(baseShape)} {Width} {Height}";
        }
    }
}