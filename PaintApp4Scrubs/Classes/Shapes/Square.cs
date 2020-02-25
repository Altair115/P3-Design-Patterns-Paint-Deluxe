using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PaintApp4Scrubs.Classes.Shapes
{
    class Square : Shape
    {
        protected override Geometry DefiningGeometry
        {
            get
            {
                
                Point p1 = new Point(0.0d, 0.0d);
                Point p2 = new Point(0,this.Height);
                Point p3 = new Point(this.Width, this.Height);
                Point p4 = new Point(this.Width, 0.0d);

                List<PathSegment> segments = new List<PathSegment>(3);
                segments.Add(new LineSegment(p1, true));
                segments.Add(new LineSegment(p2, true));
                segments.Add(new LineSegment(p3, true));
                segments.Add(new LineSegment(p4, true));

                List<PathFigure> figures = new List<PathFigure>(1);
                PathFigure pf = new PathFigure(p1, segments, true);
                figures.Add(pf);

                Geometry g = new PathGeometry(figures, FillRule.EvenOdd, null);

                return g;
            }
        }
    }

}
