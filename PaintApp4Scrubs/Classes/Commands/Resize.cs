using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Classes.Commands;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Commands
{
    /// <summary>
    /// This class creates a command to resize the shape on the canvas
    /// </summary>
    class Resize : ICommand
    {
        private readonly GodShape _shape;
        private readonly Vector _distance;
        /// <summary>
        /// the constructor of the Resize class
        /// </summary>
        /// <param name="shape">the shape that has to be resized</param>
        /// <param name="distance">the distance of the old shape and the new shape</param>
        public Resize(GodShape shape, Vector distance)
        {
            _shape = shape;
            _distance = distance;
        }
        /// <summary>
        /// executes the resize command
        /// </summary>
        public void Execute()
        {
            _shape.Resize(_distance);
        }
        /// <summary>
        /// executes the undo version of the resize command 
        /// </summary>
        public void UnExecute()
        {
            _shape.Resize(_distance * -1);
        }
    }
}
