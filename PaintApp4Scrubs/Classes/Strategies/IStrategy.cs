using System.Windows;
using System.Windows.Media;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Strategies
{
    public interface IStrategy
    {
        public Geometry GetGeometry();
        public double Height { get; set; }
        public double Width { get; set; }
        public string GetString(BaseShape baseShape);
        public void Accept(IVisitor visitor, BaseShape baseShape);

        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

    }
}