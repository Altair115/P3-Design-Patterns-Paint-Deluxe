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

        private readonly IComponent _component;

        /// <summary>
        /// constructor of the command
        /// </summary>
        /// <param name="component">the component to be deleted</param>
        public Delete(IComponent component)
        {
            _component = component;
        }
        /// <summary>
        /// deletes the component commands
        /// </summary>
        public void Execute()
        {
            _component.Accept(new VisitorDelete());
        }
        /// <summary>
        /// executes the undo version of the command
        /// </summary>
        public void UnExecute()
        {
            _component.Accept(new VisitorDraw());
        }

    }
}
