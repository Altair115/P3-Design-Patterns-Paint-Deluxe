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
    public abstract class GodShape : Shape
    {

        private List<GodShape> childrenOfGodShapes;

        protected GodShape()
        {
            childrenOfGodShapes = new List<GodShape>();
        }
        public abstract void Accept(IVisitor visitor);
        public abstract string ToString();

        public void AddChild(GodShape aShape)
        {
            childrenOfGodShapes.Add(aShape);
        }

        public void RemoveChild(GodShape aShape)
        {
            childrenOfGodShapes.Remove(aShape);
        }

        public List<GodShape> GetChildrenOfGodShapes()
        {
            return childrenOfGodShapes;
        }

        public void Display(GodShape aShape, string indent = "", bool head = true)
        {
            if (head)
            {
                PrintToFile(aShape.ToString());
                if (childrenOfGodShapes.Count > 1)
                {
                    PrintToFile($"Group {aShape.childrenOfGodShapes.Count.ToString()}");
                }
            }
            indent += " ";
            foreach (var child in childrenOfGodShapes)
            {
                if (child.childrenOfGodShapes.Count <= 0)
                {
                    PrintToFile($"{indent} {child.ToString()}");
                }
                else
                {
                    PrintToFile($"{indent} {child.ToString()}");
                    PrintToFile($"{indent} Group {child.childrenOfGodShapes.Count}");
                    child.Display(child, indent, false);
                }
            }
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
