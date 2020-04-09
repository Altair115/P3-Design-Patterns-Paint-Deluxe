using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PaintApp4Scrubs.Classes.Shapes
{
    public class Ellipse : GodShape
    {
        public static readonly DependencyProperty XRadiusDependencyProperty = DependencyProperty.Register("Xradius", typeof(Double), typeof(Ellipse));
        public static readonly DependencyProperty YRadiusDependencyProperty = DependencyProperty.Register("Yradius", typeof(Double), typeof(Ellipse));
        // static readonly DependencyProperty CenterPointDependencyProperty = DependencyProperty.Register("centerPoint", typeof(Double), typeof(Ellipse));

        private EllipseGeometry ellipse = new EllipseGeometry();
        //private Point Center = new Point(0,0);
        private double xRadius = 0;
        private double yRadius = 0;

        public double Xradius
        {
            get { return (double)this.GetValue(XRadiusDependencyProperty); }
            set { this.SetValue(XRadiusDependencyProperty, value); xRadius = value; }
        }
        public double Yradius
        {
            get { return (double)this.GetValue(XRadiusDependencyProperty); }
            set { this.SetValue(XRadiusDependencyProperty, value); yRadius = value; }
        }
        //public Point centerPoint
        //{
        //    get { return (Point)this.GetValue(CenterPointDependencyProperty); }
        //    set { this.SetValue(CenterPointDependencyProperty, value); Center = value; }
        //}


        protected override Geometry DefiningGeometry
        {
            get
            {
                
                ellipse.RadiusX = xRadius;
                ellipse.RadiusY = yRadius;
                return ellipse;
            }
        }
        public override void Resize(Vector distance)
        {
            if (!(this.xRadius > distance.X) || !(this.yRadius > distance.Y)) return;
            xRadius -= distance.X;
            yRadius -= distance.Y;
            this.ellipse.RadiusX = xRadius;
            this.ellipse.RadiusY = yRadius;

        }
        public override void Move(Vector newposition)
        {
            Canvas.SetLeft(this,newposition.X);
            Canvas.SetTop(this,newposition.Y);
        }
    }
}
