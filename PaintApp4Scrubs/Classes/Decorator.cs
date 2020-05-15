using PaintApp4Scrubs.Classes.Shapes;

namespace PaintApp4Scrubs.Classes
{
    public abstract class Decorator : GodShape
    {
        protected GodShape component;

        public void SetComponent(GodShape component)
        {
            this.component = component;
        }

        public override void Decorate()
        {
            if (component != null)
            {
                component.Decorate();
            }
        }

    }
}