using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Windows;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Classes.VisitorCommands;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes
{
    public class Boxer : IComponent
    {
        private readonly List<IComponent> _components = new List<IComponent>();

        /// <summary>
        /// Gets & Sets the depth needed for printing
        /// </summary>
        public string Depth { get; set; }
        /// <summary>
        /// Adds the component to a box
        /// </summary>
        /// <param name="component">the component to be added</param>
        public void Add(IComponent component)
        {
            component.Depth += "-";
            if (component is Boxer)
            {
                var x = (Boxer) component;
                foreach (var comp in x.GetChildren())
                {
                    comp.Depth += "-";
                    if (comp is Boxer)
                    {
                        var y = (Boxer) comp;
                        y.Indentation();
                    }
                }
            }
            _components.Add(component);
        }

        /// <summary>
        /// the indentation needed for printing of the hierarchy
        /// </summary>
        public void Indentation()
        {
            foreach (var comp in this.GetChildren())
            {
                if (comp is Boxer)
                {
                    var x = (Boxer)comp;
                    x.Depth += "-";
                    x.Indentation();
                }
                comp.Depth += "-";
            }
        }
        /// <summary>
        /// Adds the component to a box
        /// </summary>
        /// <param name="component">the component to be added</param>
        /// <param name="depth">the depth if nested deeper in the hierarchy</param>
        public void Add(IComponent component , string depth)
        {
            component.Depth = depth;
            _components.Add(component);
        }
        /// <summary>
        /// detaches the component from its box
        /// </summary>
        /// <param name="component">the component to be detached</param>
        public void Detach(IComponent component)
        {
            _components.Remove(component);
        }
        public Boxer FindBox( GodShape shape, bool head = true)
        {
            foreach (var component in _components)
            {
                if (component.Equals(shape))
                {
                    if (!head)
                        return this;

                    return null;
                } 
                
                if(component is Boxer)
                {
                    Boxer x = (Boxer) component;
                    var y = x.FindBox(shape, false);
                    if (y != null)
                        return y;
                }
            }
            return null;
        }
        /// <summary>
        /// Gets the children of the box
        /// </summary>
        /// <returns>A list of children</returns>
        public List<IComponent> GetChildren()
        {
            return _components;
        }

        /// <summary>
        /// Accept a visitor
        /// </summary>
        /// <param name="visitor">the visitor in question</param>
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
