using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

        private readonly LineGeometry _line = new LineGeometry();
        private Point _start = new Point(0, 0);
        private Point _end = new Point(0, 0);
        private Point _translation;

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
                _line.StartPoint = _start;
                _line.EndPoint = _end;
                return _line;
            }
        }

        /// <summary>
        /// resizes the line accordingly 
        /// </summary>
        /// <param name="distance">the distance new size of the line</param>
        public override void Resize(Vector distance)
        {
            X2 -= distance.X;
            Y2 -= distance.Y;
            _line.EndPoint = _end;
        }
        /// <summary>
        /// moves the line accordingly 
        /// </summary>
        /// <param name="translationToNewPosition">Contains the Translation to the new position</param>
        public override void Move(Vector translationToNewPosition)
        {
            _translation = Converter.ToPoint(translationToNewPosition);

            _start.X = _start.X - _translation.X;
            _start.Y = _start.Y - _translation.Y;

            _end.X = _end.X - _translation.X;
            _end.Y = _end.Y - _translation.Y;

            _line.StartPoint = _start;
            _line.EndPoint = _end;
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
    }
}
