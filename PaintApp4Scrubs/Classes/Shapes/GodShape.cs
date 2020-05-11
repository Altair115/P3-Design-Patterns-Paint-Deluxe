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
        public Vector _originPos;
        public abstract override string ToString();

        public virtual void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
        /// <summary>
        /// Move the shape to a new position
        /// </summary>
        /// <param name="translationToNewPosition">Contains the Translation to the new position</param>
        public virtual void Move(Vector translationToNewPosition)
        {
            _originPos = this.GetCenter();
            Vector result = Vector.Subtract(_originPos, translationToNewPosition);
            var left = result.X - (this.Width / 2);
            var top = result.Y - (this.Height / 2);
            Canvas.SetLeft(this, left);
            Canvas.SetTop(this, top);
        }

        public virtual Vector GetCenter()
        {
            var center = new Vector((Canvas.GetLeft(this) + (this.Width / 2)), Canvas.GetTop(this) + (this.Height / 2));
            return center;
        }

        public string Depth { get; set; }
    }
}
