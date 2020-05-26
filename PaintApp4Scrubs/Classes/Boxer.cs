using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Windows;
using System.Windows.Media;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Classes.VisitorCommands;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes
{
    public class Boxer : GodShape
    {
        public override double StrategyHeight { get; set; }
        private readonly List<GodShape> _components = new List<GodShape>();

        /// <summary>
        /// Gets & Sets the depth needed for printing
        /// </summary>
        public string Depth { get; set; }
        
        /// <summary>
        /// Adds the component to a box
        /// </summary>
        /// <param name="component">the component to be added</param>
        public void Add(GodShape component)
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
        public void Add(GodShape component , string depth)
        {
            component.Depth = depth;
            _components.Add(component);
        }

        /// <summary>
        /// detaches the component from its box
        /// </summary>
        /// <param name="component">the component to be detached</param>
        public void Detach(GodShape component)
        {
            _components.Remove(component);
        }
        public Boxer FindBox(GodShape shape, bool head = true)
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
        public List<GodShape> GetChildren()
        {
            return _components;
        }
        
        public override Vector GetCenter()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Accept a visitor
        /// </summary>
        /// <param name="visitor">the visitor in question</param>
        public override GodShape GetBaseShape()
        {
            throw new NotImplementedException();
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override double StrategyWidth { get; set; }

        protected override Geometry DefiningGeometry { get; }
    }
}
