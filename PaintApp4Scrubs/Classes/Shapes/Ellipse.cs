using System;
using System.Windows;
using System.Windows.Media;

namespace PaintApp4Scrubs.Classes.Shapes
{
    public class Ellipse : GodShape
    {
        public static readonly DependencyProperty RadiusXdDependencyProperty = DependencyProperty.Register("Y2", typeof(Double), typeof(Ellipse));
        public static readonly DependencyProperty RadiusYdDependencyProperty = DependencyProperty.Register("Y2", typeof(Double), typeof(Ellipse));
        public static readonly DependencyProperty CenterDependencyProperty = DependencyProperty.Register("Y2", typeof(Point), typeof(Ellipse));
        
        private EllipseGeometry ellipse = new EllipseGeometry();
        private Point Center = new Point(0,0);
        private double xRadius = 0;
        private double yRadius = 0;

        public double radiusX
        {
            get { return (double)this.GetValue(RadiusXdDependencyProperty); }
            set { this.SetValue(RadiusXdDependencyProperty, value); radiusX = value; }
        }
        public double radiusY
        {
            get { return (double)this.GetValue(RadiusYdDependencyProperty); }
            set { this.SetValue(RadiusYdDependencyProperty, value); radiusY = value; }
        }
        public Point CenterPoint
        {
            get { return (Point)this.GetValue(CenterDependencyProperty); }
            set { this.SetValue(CenterDependencyProperty, value); Center = value; }
        }

        protected override Geometry DefiningGeometry
        {
            get
            {
                ellipse.Center = Center;
                ellipse.RadiusX = xRadius;
                ellipse.RadiusY = yRadius;
                return ellipse;
            }
        }
    }
}
