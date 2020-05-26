using System.Security.Cryptography.X509Certificates;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Classes.VisitorCommands;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Commands
{
    /// <summary>
    /// Displays the hierarchy of the selected component 
    /// </summary>
    public class DisplayGroup : ICommand
    {
        private readonly GodShape _component;

<<<<<<< HEAD
        /// <param name="component">the selected component</param>
        /// </summary>
        /// the constructor of DisplayGroup
        /// <summary>
        public DisplayGroup(GodShape component)
=======
        /// <summary>
        /// the constructor of DisplayGroup
        /// </summary>
        /// <param name="component">the selected component</param>
        public DisplayGroup(IComponent component)
>>>>>>> master
        {
            _component = component;
        }
        /// <summary>
        /// Executes the visitor on the component 
        /// </summary>
        public void Execute()
        {
            _component.Accept(new VisitorDisplay(false));
        }
        /// <summary>
        /// you can Unexecute this
        /// </summary>
        public void UnExecute()
        {
            throw new System.NotImplementedException();
        }
    }
}