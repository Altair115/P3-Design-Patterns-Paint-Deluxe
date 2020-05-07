using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Classes.Commands;
using PaintApp4Scrubs.Classes.VisitorCommands;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Commands
{
    /// <summary>
    /// This class creates a command to move the component on the canvas
    /// </summary>
    class Move : ICommand
    {
        private readonly IComponent _component;
        private readonly Vector _newPosition;
        private readonly Vector _oldPosition;
        private readonly VisitorMove _visitorMove;

        /// <summary>
        /// the constructor of the Move class 
        /// </summary>
        /// <param name="component">the component that needs to be moved</param>
        /// <param name="newPosition">the new position where the component needs to go</param>
        public Move(IComponent component, Vector newPosition, Vector startPoint)
        {
            _component = component;
            _newPosition = newPosition;            
            _visitorMove = new VisitorMove(_newPosition);
        }

        /// <summary>
        /// executes the move command 
        /// </summary>
        public void Execute()
        {
            _component.Accept(_visitorMove);
        }
        /// <summary>
        /// executes the undo version of the command 
        /// </summary>
        public void UnExecute()
        {
            _visitorMove.NewPosition = _visitorMove.OldPosition;
            _component.Accept(_visitorMove);
        }
    }
}

