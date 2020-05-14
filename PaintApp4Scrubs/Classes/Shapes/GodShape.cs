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
        public abstract override string ToString();
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public string Depth { get; set; }
    }
}