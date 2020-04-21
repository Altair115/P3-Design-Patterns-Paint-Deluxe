﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace PaintApp4Scrubs.Classes.Shapes
{
    /// <summary>
    /// an abstract class to add extra functionality to the Shape class
    /// </summary>
    public abstract class GodShape : Shape
    {
        private List<GodShape> childrenOfGodShapes;

        public GodShape()
        {
            childrenOfGodShapes = new List<GodShape>();
        }

        public void AddChild(GodShape aShape)
        {
            childrenOfGodShapes.Add(aShape);
        }

        public void RemoveChild(GodShape aShape)
        {
            childrenOfGodShapes.Remove(aShape);
        }

        public List<GodShape> GetChildrenOfGodShapes(GodShape aShape)
        {
            return aShape.childrenOfGodShapes;
        }

        public List<string> Display(GodShape aShape)
        {
            List<string> lines = new List<string>();
            foreach (var child in childrenOfGodShapes)
            {
                lines.Add(child.ToString());
                lines.Add(child.Display(child).ToString());
            }
            System.IO.File.WriteAllLines(@"\GitHub\P3-Design-Patterns-Paint-Deluxe\Comptest.txt", lines);
            return lines;
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
            Canvas.SetLeft(this,left);
            Canvas.SetTop(this,top);
        }

        public virtual Vector GetCenter()
        {
            var center = new Vector((Canvas.GetLeft(this) + (this.Width / 2)), Canvas.GetTop(this) + (this.Height / 2));
            return center;
        }
    }
}
