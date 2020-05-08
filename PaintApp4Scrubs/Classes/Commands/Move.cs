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
        private readonly Vector _positionResult;
        private readonly VisitorMove _visitorMove;

        /// <summary>
        /// the constructor of the Move class 
        /// </summary>
        /// <param name="component">the component that needs to be moved</param>
        /// <param name="newPosition">the new position where the component needs to go</param>
        /// <param name="oldPosition">the old position of the component</param>
        public Move(IComponent component, Vector newPosition, Vector oldPosition)
        {
            _component = component;
            _newPosition = newPosition;
            _oldPosition = oldPosition;
            _positionResult = _oldPosition + -1 * _newPosition;
        }

        /// <summary>
        /// executes the move command 
        /// </summary>
        public void Execute()
        {
            _component.Accept(new VisitorMove(Vector.Subtract(_oldPosition, _positionResult)));
        }
        /// <summary>
        /// executes the undo version of the command 
        /// </summary>
        public void UnExecute()
        {
            _component.Accept(new VisitorMove(Vector.Add(_newPosition, _positionResult)));
        }
    }
}

