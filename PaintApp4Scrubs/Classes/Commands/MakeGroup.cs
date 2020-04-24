using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Commands
{
    public class MakeGroup : ICommand
    {
        private readonly IComponent _firstComponent;
        private readonly IComponent _secondComponent;
        private readonly Boxer _parrentBox;
        private readonly Boxer _newBox;

        public MakeGroup(IComponent firstComponent, IComponent secondComponent , Boxer parrentBox)
        {
            _firstComponent = firstComponent;
            _secondComponent = secondComponent;
            _parrentBox = parrentBox;
            _newBox = new Boxer();
        }
        public void Execute()
        {
            _newBox.Add(_firstComponent);
            _newBox.Add(_secondComponent);
            _parrentBox.Detach(_firstComponent);
            _parrentBox.Detach(_secondComponent);
            _parrentBox.Add(_newBox);
        }

        public void UnExecute()
        {
            _parrentBox.Detach(_newBox);
        }
    }
}