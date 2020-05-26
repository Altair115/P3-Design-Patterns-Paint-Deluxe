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
        private readonly List<GodShape> _components = new List<GodShape>();
        public override double StrategyHeight { get; set; }
        public string Depth { get; set; }
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
        public void Add(GodShape component , string depth)
        {
            component.Depth = depth;
            _components.Add(component);
        }

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
        public List<GodShape> GetChildren()
        {
            return _components;
        }
        
        public override Vector GetCenter()
        {
            throw new NotImplementedException();
        }

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
