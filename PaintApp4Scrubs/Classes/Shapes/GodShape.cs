using System.Windows;
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

        public virtual void Resize(Vector distance)
        {
            if (!(this.Width > distance.X) || !(this.Height > distance.Y)) return;
            this.Width -= distance.X;
            this.Height -= distance.Y;
        }

    }
}
