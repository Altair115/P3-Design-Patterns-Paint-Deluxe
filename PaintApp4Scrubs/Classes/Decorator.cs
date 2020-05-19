using System.Windows;
using PaintApp4Scrubs.Classes.Shapes;

namespace PaintApp4Scrubs.Classes
{
    public abstract class Decorator : GodShape
    {
        protected GodShape _component;

        public Decorator(GodShape p)
        {
            _component = p;
        }
        public void SetComponent(GodShape component)
        {
            _component = component;
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