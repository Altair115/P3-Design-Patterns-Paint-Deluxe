using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace PaintApp4Scrubs.Classes.Shapes
{
    /// <summary>
    /// an abstract class to add extra functunality to the Shap class
    /// </summary>
    public abstract class GodShape : Shape
    {
        /// <summary>
        /// draws the shape on the canvas
        /// </summary>
        public void Draw()
        {
            MainWindow.AppWindow.PutOnScreen(this);

        }
        /// <summary>
        /// removes the shape of the canvas
        /// </summary>
        public void Remove()
        {
            
            MainWindow.AppWindow.RemoveShape(this);
        }
        /// <summary>
        /// resizes the shape 
        /// </summary>
        /// <param name="distance">the new point to resize to</param>
        public virtual void Resize(Vector distance)
        {
            if (!(this.Width > distance.X) || !(this.Height > distance.Y)) return;
            this.Width -= distance.X;
            this.Height -= distance.Y;
        }
        /// <summary>
        /// Move the shape to a new position
        /// </summary>
        /// <param name="newPosition">the new position to move to</param>
        public virtual void Move(Vector newPosition)
        {
            var left = newPosition.X - (this.Width / 2);
            var top = newPosition.Y - (this.Height / 2);
            Canvas.SetLeft(this,left);
            Canvas.SetTop(this,top);
            
        }
    }
}
