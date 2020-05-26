using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using PaintApp4Scrubs.Interfaces;


namespace PaintApp4Scrubs.Classes.Shapes
{

    /// <summary>
    /// an abstract class to add extra functionality to the Shape class
    /// </summary>
    public abstract class GodShape : Shape, IComponent 
    {
        public Vector OriginPos;
        public abstract void Decorate();
        public abstract Vector GetCenter();
        public abstract GodShape GetBaseShape();
        public abstract void Accept(IVisitor visitor);
        public abstract double StrategyWidth { get; set; }
        public abstract double StrategyHeight { get; set; }
        public string Depth { get; set; }
    }
}