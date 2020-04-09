using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace PaintApp4Scrubs.Classes.Shapes
{
    public abstract class GodShape : Shape
    {
        private Vector centerpoint;
        private List<GodShape> children;
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

        public virtual void Move(Vector newposition)
        {
            double topleft = newposition.X - (this.Width / 2);
            double settop = newposition.Y - (this.Height / 2);
            Canvas.SetLeft(this,topleft);
            Canvas.SetTop(this,settop);
            
        }
    }
}
