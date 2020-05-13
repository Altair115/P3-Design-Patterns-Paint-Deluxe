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

        public void Accept(BaseShape baseShap , IVisitor visitor)
        {
            //maak aparte visit methode 
            //visitor.Visit();
        }
        public double Height { get; set; }
        public double Width { get; set; }
        public string GetString(BaseShape baseShape)
        {
            throw new System.NotImplementedException();
        }
    }
}