using System.Windows;
using System.Windows.Media;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Strategies
{
    public class EllipseStrategies : IStrategy
    {
        public EllipseGeometry EllipseGeometry = new EllipseGeometry();
        private double _xRadius;
        private double _yRadius;

        public EllipseStrategies(double xRadius, double yRadius)
        {
            _yRadius = yRadius;
            _xRadius = xRadius;
        }
        public Geometry GetGeometry()
        {
            EllipseGeometry.RadiusX = Width;
            EllipseGeometry.RadiusY = Height;
            return EllipseGeometry;
        }
        public double Height
        {
            get { return _yRadius;}
            set { EllipseGeometry.RadiusY = value;
                _yRadius = value;
            }
        }
        public double Width
        {
            get { return _xRadius;}
            set { EllipseGeometry.RadiusX = value; _xRadius = value;
            }
        }
        public string GetString(BaseShape baseShape)
        {
            throw new System.NotImplementedException();
        }
        public void Accept(IVisitor visitor, BaseShape baseShape)
        {
            visitor.VisitEllipse(baseShape);
        }

        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
    }
}