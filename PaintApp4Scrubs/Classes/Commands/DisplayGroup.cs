using System.Security.Cryptography.X509Certificates;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Commands
{
    public class DisplayGroup : ICommand
    {
        private readonly IComponent _component;

        public DisplayGroup(IComponent component)
        {
            _component = component;
        }
        public void Execute()
        {
            _component.ClearFile();
            _component.Display();
        }

        public void UnExecute()
        {
            throw new System.NotImplementedException();
        }
    }
}