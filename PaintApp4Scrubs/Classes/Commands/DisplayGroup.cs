using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Commands
{
    public class DisplayGroup : ICommand
    {
        private GodShape _shape;

        public DisplayGroup(GodShape shape)
        {
            _shape = shape;
        }
        public void Execute()
        {
            _shape.ClearFile();
            _shape.Display(_shape);
        }

        public void UnExecute()
        {
            throw new System.NotImplementedException();
        }
    }
}