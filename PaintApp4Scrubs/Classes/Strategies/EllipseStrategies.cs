using System.Windows.Media;
using PaintApp4Scrubs.Classes.Shapes;

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

        public double Height { get; set; }
        public double Width { get; set; }
        public string GetString(BaseShape baseShape)
        {
            throw new System.NotImplementedException();
        }
    }
}