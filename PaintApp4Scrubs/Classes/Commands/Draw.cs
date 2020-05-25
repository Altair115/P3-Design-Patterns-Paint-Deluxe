using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;
using PaintApp4Scrubs.Classes.VisitorCommands;

namespace PaintApp4Scrubs.Classes.Commands
{
    /// <summary>
    /// This class creates a command to draw an shape on the canvas
    /// </summary>
    public class Draw : ICommand
    {
        private readonly GodShape _component;
        /// <summary>
        /// the constructor of the Draw class
        /// </summary>
        /// <param name="component"></param>
        public Draw(GodShape component)
        {
            _component = component;
        }

        /// <summary>
        /// execute the Visitor with the VistorDraw();
        /// </summary>
        public void Execute()
        {
            _component.Accept(new VisitorDraw());
        }
        /// <summary>
        /// executes the undo variant of visitor
        /// </summary>
        public void UnExecute()
        {
            _component.Accept(new VisitorDelete());
        }
    }
}
