using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using PaintApp4Scrubs.Classes.VisitorCommands;

namespace PaintApp4Scrubs.Classes.Commands
{
    /// <summary>
    /// This class creates a command to delete the component from the canvas
    /// </summary>
    class Delete : ICommand
    {
        private readonly GodShape _component;

        /// <summary>
        /// constructor of the command
        /// </summary>
        /// <param name="component">the component to be deleted</param>
        public Delete(GodShape component)
        {
            _component = component;
        }
        /// <summary>
        /// calls the visitor on the component
        /// </summary>
        public void Execute()
        {
            _component.Accept(new VisitorDelete());
        }
        /// <summary>
        /// calls the undo variant of the visitor
        /// </summary>
        public void UnExecute()
        {
            _component.Accept(new VisitorDraw());
        }

    }
}
