using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PaintApp4Scrubs.Classes.Shapes
{

    /// <summary>
    /// this class creates a _ellipse 
    /// </summary>
    public class Ellipse : GodShape
    {
        public static readonly DependencyProperty XRadiusDependencyProperty = DependencyProperty.Register("XRadius", typeof(Double), typeof(Ellipse));
        public static readonly DependencyProperty YRadiusDependencyProperty = DependencyProperty.Register("YRadius", typeof(Double), typeof(Ellipse));
        // static readonly DependencyProperty CenterPointDependencyProperty = DependencyProperty.Register("centerPoint", typeof(Double), typeof(Ellipse));

        private readonly EllipseGeometry _ellipse = new EllipseGeometry();
        //private Point Center = new Point(0,0);
        private double _xRadius;
        private double _yRadius;

        /// <summary>
        /// gets en sets the x radius
        /// </summary>
        public double XRadius
        {
            get { return (double) GetValue(XRadiusDependencyProperty); }
            set { SetValue(XRadiusDependencyProperty, value); _xRadius = value; }
        }
        /// <summary>
        /// gets and sets the y radius
        /// </summary>
        public double YRadius
        {
            get { return (double) GetValue(YRadiusDependencyProperty); }
            set { SetValue(YRadiusDependencyProperty, value); _yRadius = value; }
        }
        //public Point centerPoint
        //{
        //    get { return (Point)this.GetValue(CenterPointDependencyProperty); }
        //    set { this.SetValue(CenterPointDependencyProperty, value); Center = value; }
        //}

        /// <summary>
        /// gets the geometry for the ellipse
        /// </summary>
        protected override Geometry DefiningGeometry
        {
            get
            {
                
                _ellipse.RadiusX = _xRadius;
                _ellipse.RadiusY = _yRadius;
                return _ellipse;
            }
        }
        /// <summary>
        /// Resizes the ellipse accordingly 
        /// </summary>
        /// <param name="distance">the new point to be resize to </param>
        public override void Resize(Vector distance)
        {
            if (!(_xRadius > distance.X) || !(_yRadius > distance.Y)) return;
            _xRadius -= distance.X;
            _yRadius -= distance.Y;
            _ellipse.RadiusX = _xRadius;
            _ellipse.RadiusY = _yRadius;

        }
        /// <summary>
        /// moves the ellipse accordingly 
        /// </summary>
        /// <param name="newPosition">the new position to move to </param>
        public override void Move(Vector newPosition)
        {
            Canvas.SetLeft(this, newPosition.X);
            Canvas.SetTop(this, newPosition.Y);
        }

        public override Vector GetCenter()
        {
            var center = new Vector(Canvas.GetLeft(this), Canvas.GetTop(this));
            return center;
        }
    }
}
