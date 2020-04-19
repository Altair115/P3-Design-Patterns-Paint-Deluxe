using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Classes.Commands;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Commands
{
    /// <summary>
    /// This class creates a command to move the shape on the canvas
    /// </summary>
    class Move : ICommand
    {
        private readonly GodShape _shape;
        private readonly Vector _newPosition;
        private readonly Vector _oldPosition;

        /// <summary>
        /// the constructor of the Move class 
        /// </summary>
        /// <param name="shape">the shape that needs to be moved</param>
        /// <param name="newPosition">the new position where the shape needs to go</param>
        public Move(GodShape shape, Vector newPosition, Vector startPoint)
        {
            _shape = shape;
            _newPosition = newPosition;
            _oldPosition = _shape.GetCenter();



        }

        /// <summary>
        /// executes the move command 
        /// </summary>
        public void Execute()
        {
            _shape.Move(_newPosition);
        }
        /// <summary>
        /// executes the undo version of the command 
        /// </summary>
        public void UnExecute()
        {
            _shape.Move(_oldPosition);
        }
    }
}

