using System.Collections.Generic;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Commands
{
    public class MakeGroup : ICommand
    {
        private readonly List<IComponent> _components;
        private readonly Boxer _parentBox;
        private readonly Boxer _newBox;

        public MakeGroup(List<IComponent> components, Boxer parentBox)
        {
            _components = components;
            _parentBox = parentBox;
            _newBox = new Boxer();
        }
        public void Execute()
        {
            foreach (var component in _components)
            {
                _newBox.Add(component);
                _parentBox.Detach(component);
            }
            _parentBox.Add(_newBox);
        }

        public void UnExecute()
        {
            _parentBox.Detach(_newBox);
        }
    }
}