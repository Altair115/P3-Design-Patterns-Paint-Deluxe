using System.Windows;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

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

        public  GodShape GetComponent()
        {
            return _component;
        }

        public override GodShape GetBaseShape()
        {
            return _component.GetBaseShape();
        }

        public override Vector GetCenter()
        {
            return _component.GetCenter();
        }
        public override double StrategyWidth
        {
            get { return _component.StrategyWidth; }
        }
        public override double StrategyHeight
        {
            get { return _component.StrategyHeight; }
        }

        public override string Depth
        {
            get { return _component.Depth; }
            set { _component.Depth = value; }
        }
    }
}