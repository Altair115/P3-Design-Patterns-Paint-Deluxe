using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Shapes
{
    /// <summary>
    /// this class creates the Line
    /// </summary>
    public class Line : GodShape
    {
        public static readonly DependencyProperty X1DependencyProperty = DependencyProperty.Register("X1", typeof(Double), typeof(Line));
        public static readonly DependencyProperty X2DependencyProperty = DependencyProperty.Register("X2", typeof(Double), typeof(Line));
        public static readonly DependencyProperty Y1DependencyProperty = DependencyProperty.Register("Y1", typeof(Double), typeof(Line));
        public static readonly DependencyProperty Y2DependencyProperty = DependencyProperty.Register("Y2", typeof(Double), typeof(Line));
       
        private Point _start = new Point(0, 0);
        private Point _end = new Point(0, 0);

        public LineGeometry LineGeometry { get; set; }

        public Point StartPoint
        {
            get { return _start;}
            set { _start = value;}
        } 
        public Point EndPoint
        {
            get { return _end;}
            set { _end = value;}
        }
        

        public Line()
        {
            LineGeometry = new LineGeometry();
        }
        public double X1
        {
            get { return (double)GetValue(X1DependencyProperty); }
            set { this.SetValue(X1DependencyProperty, value); _start.X = value; }
        }
        public double Y1
        {
            get { return (double)GetValue(Y1DependencyProperty); }
            set { SetValue(Y1DependencyProperty, value); _start.Y = value; }
        }
        public double X2
        {
            get { return (double)GetValue(X2DependencyProperty); }
            set { SetValue(X2DependencyProperty, value); _end.X = value; }
        }
        public double Y2
        {
            get { return (double)GetValue(Y2DependencyProperty); }
            set { SetValue(Y2DependencyProperty, value); _end.Y = value; }
        }
        /// <summary>
        /// defines the geometry of the line
        /// </summary>
        protected override Geometry DefiningGeometry
        {
            get
            {
                LineGeometry.StartPoint = _start;
                LineGeometry.EndPoint = _end;
                return LineGeometry;
            }
        }
        
        public override Vector GetCenter()
        {
            var center = new Vector((X1 + X2) / 2, (Y1 + Y2)/2);
            return center;
        }
        public override string ToString()
        {
            return $"Line {Canvas.GetLeft(this)} {Canvas.GetTop(this)} {_start} {_end}";
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
