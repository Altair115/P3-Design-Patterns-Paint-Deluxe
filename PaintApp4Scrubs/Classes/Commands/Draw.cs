using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Controls;
using PaintApp4Scrubs.Interfaces;
using PaintApp4Scrubs.Classes.Shapes;

namespace PaintApp4Scrubs.Classes.Commands
{
    /// <summary>
    /// This class creates a command to draw an shape on the canvas
    /// </summary>
    public class Draw : ICommand
    {
        private readonly GodShape _shape;
        /// <summary>
        /// the constructor of the Draw class
        /// </summary>
        /// <param name="shape"></param>
        public Draw(GodShape shape)
        {
            _shape = shape;
        }

        /// <summary>
        /// execute the draw command
        /// </summary>
        public void Execute()
        {
            _shape.Draw();
        }
        /// <summary>
        /// executes the undo version of the command
        /// </summary>
        public void UnExecute()
        {
            _shape.Remove();
        }
    }
}
