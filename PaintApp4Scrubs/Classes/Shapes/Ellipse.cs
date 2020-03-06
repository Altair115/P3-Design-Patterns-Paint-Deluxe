using System.Windows;
using System.Windows.Media;

namespace PaintApp4Scrubs.Classes.Shapes
{
public class Ellipse : GodShape
{
    protected override Geometry DefiningGeometry
    {
        get
        {
            Point ellipseCenter = new Point(0.0d, 0.0d);
            var ellipse = new EllipseGeometry(ellipseCenter, ActualWidth, ActualHeight);

            return ellipse;
        }
    }
}
}