using System.Windows;
using PaintApp4Scrubs.Classes.Shapes;

namespace PaintApp4Scrubs.Classes
{
    public abstract class Decorator : GodShape
    {
        protected GodShape _component;
        protected double width;
        protected double height;
        public Decorator(GodShape p)
        {
            _component = p;
        }
        public void SetComponent(GodShape component)
        {
            _component = component;
            width = component.Width;
            height = component.Height;
        }

        public override void Decorate()
        {
            if (_component != null)
            {
                _component.Decorate();
            }
        }

        public override Vector GetCenter()
        { 
            return _component.GetCenter();
        }
    }
}