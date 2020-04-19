using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaintApp4Scrubs.Classes.Commands
{
    /// <summary>
    /// This class creates a command to delete the shape from the canvas
    /// </summary>
    class Delete : ICommand
    {

        private readonly GodShape _shape;

        /// <summary>
        /// constructor of the command
        /// </summary>
        /// <param name="shape">the shape to be deleted</param>
        public Delete(GodShape shape)
        {
            _shape = shape;
        }
        /// <summary>
        /// deletes the shape commands
        /// </summary>
        public void Execute()
        {
            _shape.Remove();
        }
        /// <summary>
        /// executes the undo version of the command
        /// </summary>
        public void UnExecute()
        {
            _shape.Draw();
        }

    }
}
