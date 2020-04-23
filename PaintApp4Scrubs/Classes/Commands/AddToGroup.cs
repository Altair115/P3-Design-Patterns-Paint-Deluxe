using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Commands
{
    public class AddToGroup : ICommand
    {
        private readonly GodShape _shape;
        private readonly GodShape _childShape;

        public AddToGroup(GodShape shape, GodShape childShape)
        {
            _shape = shape;
            _childShape = childShape;
        }
        public void Execute()
        {
            _shape.AddChild(_childShape);
        }

        public void UnExecute()
        {
            _shape.RemoveChild(_childShape);
        }
    }
}