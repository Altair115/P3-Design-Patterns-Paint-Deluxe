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
            if (_component is GodShape)
            {
                var x = (GodShape) _component;
                x.ClearFile();
                x.Display();
                
            }
            else
            {
                var x = (Boxer) _component;
                x.ClearFile();
                x.SaveFile();
            }
            
        }

        public void UnExecute()
        {
            throw new System.NotImplementedException();
        }
    }
}