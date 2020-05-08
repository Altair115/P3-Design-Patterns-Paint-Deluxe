using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using PaintApp4Scrubs.Classes.VisitorCommands;
using PaintApp4Scrubs.Interfaces;


namespace PaintApp4Scrubs.Classes.Shapes
{
    /// <summary>
    /// an abstract class to add extra functionality to the Shape class
    /// </summary>
    public abstract class GodShape : Shape, IComponent, IAccept
    {
        public abstract override string ToString();
        private string _depth;

        public string Depth
        {
            get { return _depth; }
            set { _depth = value; }
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Display(string depth)
        {
            PrintToFile($"{Depth}{this.ToString()}");
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

        public string GetDepth()
        {
            return _depth;
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
        /// <param name="newPosition">the new position to move to</param>
        public virtual void Move(Vector newPosition)
        {
            var left = newPosition.X - (this.Width / 2);
            var top = newPosition.Y - (this.Height / 2);
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
