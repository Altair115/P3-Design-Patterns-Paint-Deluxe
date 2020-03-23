using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace PaintApp4Scrubs.Classes.Shapes
{
    public class Line : GodShape
    {
        public static readonly DependencyProperty X1DependencyProperty = DependencyProperty.Register("X1", typeof(Double), typeof(Line));
        public static readonly DependencyProperty X2DependencyProperty = DependencyProperty.Register("X2", typeof(Double), typeof(Line));
        public static readonly DependencyProperty Y1DependencyProperty = DependencyProperty.Register("Y1", typeof(Double), typeof(Line));
        public static readonly DependencyProperty Y2DependencyProperty = DependencyProperty.Register("Y2", typeof(Double), typeof(Line));

        private LineGeometry line =
            new LineGeometry();
        private Point start = new Point(0, 0);
        private Point end = new Point(0, 0);

        public double X1
        {
            get { return (double) this.GetValue(X1DependencyProperty);}
            set {this.SetValue(X1DependencyProperty,value); start.X = value; }
        }
        public double Y1
        {
            get { return (double)this.GetValue(Y1DependencyProperty); }
            set { this.SetValue(Y1DependencyProperty, value); start.Y = value; }
        }
        public double X2
        {
            get { return (double)this.GetValue(X2DependencyProperty); }
            set { this.SetValue(X2DependencyProperty, value); end.X = value; }
        }
        public double Y2
        {
            get { return (double)this.GetValue(Y2DependencyProperty); }
            set { this.SetValue(Y2DependencyProperty, value); end.Y = value; }
        }
        public double Length;
        protected override Geometry DefiningGeometry
        {
            get
            {
                //Point p1 = new Point(X1, Y1);
                //Point p2 = new Point(X2, Y2);

                //List<PathSegment> segments = new List<PathSegment>(2);
                //segments.Add(new LineSegment(p1, true));
                //segments.Add(new LineSegment(p2, true));

                //List<PathFigure> figures = new List<PathFigure>(1);
                //PathFigure pf = new PathFigure(p1, segments, true);
                //figures.Add(pf);

                //Geometry g = new PathGeometry(figures, FillRule.EvenOdd, null);
                //Length = Point.Subtract(p2, p1).Length;
                //return g;
                line.StartPoint = start;
                line.EndPoint = end;
                return line;
            }
        }

        public override void Resize(Vector distance)
        {
            X2 -= distance.X;
            Y2 -= distance.Y;
            this.line.EndPoint = end;
        }
    }
}
