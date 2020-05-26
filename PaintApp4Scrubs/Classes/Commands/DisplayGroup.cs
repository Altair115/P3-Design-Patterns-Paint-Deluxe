using System.Security.Cryptography.X509Certificates;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Classes.VisitorCommands;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Commands
{
    public class DisplayGroup : ICommand
    {
        private readonly GodShape _component;

        public DisplayGroup(GodShape component)
        {
            _component = component;
        }
        public void Execute()
        {
            _component.Accept(new VisitorDisplay(false));
        }

        public void UnExecute()
        {
            throw new System.NotImplementedException();
        }
    }
}