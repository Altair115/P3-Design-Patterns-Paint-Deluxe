using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using PaintApp4Scrubs.Interfaces;


namespace PaintApp4Scrubs.Classes.Shapes
{

    /// <summary>
    /// an abstract class to add extra functionality to the Shape class
    /// </summary>
    public abstract class GodShape : Shape, IAccept
    {
        public Vector OriginPos;
        public abstract double StrategyHeight { get; set; }
        public abstract double StrategyWidth { get; set; }
        public abstract void Accept(IVisitor visitor);
        public abstract GodShape GetBaseShape();
        public abstract Vector GetCenter();
        public string Depth { get; set; }
    }
}