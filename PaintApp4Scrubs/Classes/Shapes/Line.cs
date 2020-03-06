using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace PaintApp4Scrubs.Classes.Shapes
{
    public class Line : GodShape
    {
        protected override Geometry DefiningGeometry
        {
            get
            {
                Point p1 = new Point(0.0d, 0.0d);
                Point p2 = new Point(this.Width, this.Height);

                List<PathSegment> segments = new List<PathSegment>(2);
                segments.Add(new LineSegment(p1, true));
                segments.Add(new LineSegment(p2, true));

                List<PathFigure> figures = new List<PathFigure>(1);
                PathFigure pf = new PathFigure(p1, segments, true);
                figures.Add(pf);

                Geometry g = new PathGeometry(figures, FillRule.EvenOdd, null);

                return g;
            }
        }
    }
}