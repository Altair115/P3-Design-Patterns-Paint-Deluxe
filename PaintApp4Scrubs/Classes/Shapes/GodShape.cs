using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using PaintApp4Scrubs.Interfaces;


namespace PaintApp4Scrubs.Classes.Shapes
{
    
    /// <summary>
    /// an abstract class to add extra functionality to the Shape class
    /// </summary>
    public abstract class GodShape : Shape, IAccept, IComponent
    {
        public Vector OriginPos;
        public abstract override string ToString();

        public virtual void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
        public virtual Vector GetCenter()
        {
            var center = new Vector((Canvas.GetLeft(this) + (this.Width / 2)), Canvas.GetTop(this) + (this.Height / 2));
            return center;
        }
        public string Depth { get; set; }
    }
}