using System.Windows;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes
{
    /// <summary>
    /// The decorator BaseClass
    /// </summary>
    public abstract class Decorator : GodShape
    {
        protected GodShape Component;
        protected double Width;
        protected double Height;

        protected Decorator(GodShape p)
        {
            Component = p;
        }
        public void SetComponent(GodShape component)
        {
            Component = component;
            Width = component.Width;
            Height = component.Height;
        }

        public  GodShape GetComponent()
        {
            return Component;
        }

        public override GodShape GetBaseShape()
        {
            return Component.GetBaseShape();
        }

        public override Vector GetCenter()
        {
            return Component.GetCenter();
        }
        public override double StrategyWidth => Component.StrategyWidth;
        public override double StrategyHeight => Component.StrategyHeight;

        public override string Depth
        {
            get => Component.Depth;
            set => Component.Depth = value;
        }
    }
}