using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Shapes
{
    /// <summary>
    /// creates the square
    /// </summary>
    public class Square : GodShape
    {
        private Geometry _geometry;
        /// <summary>
        /// defines the geometry of the square
        /// </summary>
        protected override Geometry DefiningGeometry
        {
            get
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

                _geometry = new PathGeometry(figures, FillRule.EvenOdd, null);
                
                return _geometry;
            }
        }

        public override string ToString()
        {
            return $"Rectangle {Canvas.GetLeft(this)} {Canvas.GetTop(this)} {this.Width} {this.Height}";
        }

        public override void Accept(IVisitor visitor)
        {
            throw new NotImplementedException();
        }
    }
}
