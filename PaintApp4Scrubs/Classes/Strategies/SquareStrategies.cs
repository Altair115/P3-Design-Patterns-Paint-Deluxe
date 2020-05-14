using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Classes.Strategies;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Stratagies
{
    public class SquareStrategies : IStrategy
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public SquareStrategies(double width,double height)
        {
            Height = height;
            Width = width;
        }
        public Geometry GetGeometry()
        {
          
                Point p1 = new Point(0.0d, 0.0d);
                Point p2 = new Point(0, Height);
                Point p3 = new Point(Width, Height);
                Point p4 = new Point(Width, 0.0d);

                List<PathSegment> segments = new List<PathSegment>(3);
                segments.Add(new LineSegment(p1, true));
                segments.Add(new LineSegment(p2, true));
                segments.Add(new LineSegment(p3, true));
                segments.Add(new LineSegment(p4, true));

                List<PathFigure> figures = new List<PathFigure>(1);
                PathFigure pf = new PathFigure(p1, segments, true);
                figures.Add(pf);

                Geometry geometry = new PathGeometry(figures, FillRule.EvenOdd, null);

                return geometry;
            
        }

        public string GetString(BaseShape baseShape)
        {
            return $"Rectangle {Canvas.GetLeft(baseShape)} {Canvas.GetTop(baseShape)} {this.Width} {this.Height}";
        }

        public void Accept(IVisitor visitor, BaseShape baseShape)
        {
            visitor.VisitSquare(baseShape);
        }

        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
    }
}