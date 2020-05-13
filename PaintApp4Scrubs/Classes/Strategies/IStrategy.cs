using System.Windows.Media;
using PaintApp4Scrubs.Classes.Shapes;

namespace PaintApp4Scrubs.Classes.Strategies
{
    public interface IStrategy
    {
        public Geometry GetGeometry();
        public double Height { get; set; }
        public double Width { get; set; }
        public string GetString(BaseShape baseShape);

    }
}