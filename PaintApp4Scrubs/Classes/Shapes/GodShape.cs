using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using PaintApp4Scrubs.Interfaces;


namespace PaintApp4Scrubs.Classes.Shapes
{
    
    /// <summary>
    /// an abstract class to add extra functionality to the Shape class
    /// </summary>
    public abstract class GodShape : Shape, IComponent, IAccept
    {
        private Vector _originPos;
        public abstract override string ToString();
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Display()
        {
            PrintToFile(this.ToString());
        }

        public void PrintToFile(string text)
        {
            using System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"..\..\..\..\comptest.txt", true);
            file.WriteLine(text);
        }

        public void ClearFile()
        {
            System.IO.File.WriteAllText(@"..\..\..\..\comptest.txt", "");
        }
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
    }
}
