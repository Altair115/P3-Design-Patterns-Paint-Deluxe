using System.Windows.Shapes;

namespace PaintApp4Scrubs.Classes.Shapes
{
    public abstract class GodShape : Shape
    {
        public void Draw()
        {
            MainWindow.AppWindow.PutOnScreen(this);
        }
        public void Remove()
        {
            MainWindow.AppWindow.RemoveShape(this);
        }
    }
}
