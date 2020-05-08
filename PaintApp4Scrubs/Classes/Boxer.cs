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
        public string Depth { get; set; }
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
        public void Add(IComponent component , string depth)
        {
            component.Depth = depth;
            _components.Add(component);
        }

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
        public List<IComponent> GetChildren()
        {
            return _components;
        }

        public void ClearFile()
        {
            System.IO.File.WriteAllText(@"..\..\..\..\Comptest.txt", "");
        }

        public void PrintToFile(string text)
        {
            using System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"..\..\..\..\Comptest.txt", true);
            file.WriteLine(text);
        }

        public void Accept(IVisitor visitor)
        {
            if (visitor is VisitorDisplay)
            {
                if (this.GetChildren().Count != 1)
                {
                    PrintToFile($"{Depth}Group {this.GetChildren().Count}");
                }
            }
            foreach (var x in _components)
            {
                x.Accept(visitor);
            }
        }
    }
}
