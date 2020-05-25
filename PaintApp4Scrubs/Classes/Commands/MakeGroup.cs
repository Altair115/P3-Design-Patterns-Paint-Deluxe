using System.Collections.Generic;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Commands
{
    /// <summary>
    /// Makes a group of multiple selected objects
    /// </summary>
    public class MakeGroup : ICommand
    {
        private readonly List<GodShape> _components;
        private readonly Boxer _parentBox;
        private readonly Boxer _newBox;
        public MakeGroup(List<GodShape> components, Boxer parentBox)
        /// <param name="parentBox">the parent box</param>
        /// <param name="components">the selected shapes/boxes </param>
        /// </summary>
        /// this is the constructor of MakeGroup
        /// <summary>
        {
            _components = components;
            _parentBox = parentBox;
            _newBox = new Boxer();
        }
        /// <summary>
        /// adds depth to the new box and adds the components to them and removes them the old components from the parent box 
        /// </summary>
        public void Execute()
        {
            _newBox.Depth += "-";
            foreach (var component in _components)
            {
                _newBox.Add(component);
                _parentBox.Detach(component);
            }
            _parentBox.Add(_newBox,_newBox.Depth);
        }
        /// <summary>
        /// removes the new box and adds the children to the parent box
        /// </summary>
        public void UnExecute()
        {
            _parentBox.Detach(_newBox);
            foreach (var component in _components)
            {
                _parentBox.Add(component);
            }
        }
    }
}