using System.Collections.Generic;
using System.Windows;
using System.Windows.Shapes;

namespace PaintApp4Scrubs.Classes.Shapes
{
    public abstract class GodShape : Shape
    {
        private List<GodShape> childrenOfGodShapes;

        public GodShape()
        {
            childrenOfGodShapes = new List<GodShape>();
        }

        public void AddChild(GodShape aShape)
        {
            childrenOfGodShapes.Add(aShape);
        }

        public void RemoveChild(GodShape aShape)
        {
            childrenOfGodShapes.Remove(aShape);
        }

        public List<GodShape> GetChildrenOfGodShapes()
        {
            return childrenOfGodShapes;
        }

        public string Display()
        {
            return "Group:" + childrenOfGodShapes.ToString();
        }

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
