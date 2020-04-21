using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PaintApp4Scrubs.Classes.Shapes
{
    /// <summary>
    /// this class creates a triangle
    /// </summary>
    public class Triangle : GodShape
    {
        /// <summary>
        /// defines the geometry of the shape
        /// </summary>
        protected override Geometry DefiningGeometry
        {
            get
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

                Geometry g = new PathGeometry(figures, FillRule.EvenOdd, null);

                return g;
            }
        }

        public override string ToString()
        {
            return $"Triangle {Canvas.GetLeft(this)} {Canvas.GetTop(this)} {this.Width} {this.Height}";
        }
    }
}