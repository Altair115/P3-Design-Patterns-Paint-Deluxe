using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Windows;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes
{
    public class Boxer : IComponent, IAccept
    {
        private readonly List<IComponent> _components = new List<IComponent>();
        private bool _isHead;

        public Boxer(bool head = false)
        {
            _isHead = head;
        }
        public void Add(IComponent component)
        { 
            _components.Add(component);
        }

        public void Detach(IComponent component)
        {
            _components.Remove(component);
        }
        public bool Equals(Boxer other)
        {
            return this == other;
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
        public void Display(List<IComponent> children = null, string indent = "", bool head = true)
        {
            if (head)
            {
                PrintToFile("Canvas");
                if (_components.Count > 1)
                {
                    PrintToFile($"Group {_components.Count}");
                }
                children = _components;
            }
            indent += " ";
            foreach (var child in children)
            {
                if (child is GodShape)
                {
                    PrintToFile($"{indent} {child.ToString()}");
                }
                else
                {
                    var x = (Boxer)child;
                    if (x.GetChildren().Count != 1)
                    {
                        PrintToFile($"{indent} Group {x.GetChildren().Count}");
                    }
                    this.Display(x.GetChildren(), indent, false);
                }
            }
        }
        
        public void ClearFile()
        {
            System.IO.File.WriteAllText(@"..\..\..\..\savetest.txt", "");
        }

        public void PrintToFile(string text)
        {
            using System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"..\..\..\..\savetest.txt", true);
            file.WriteLine(text);
        }

        public void Resize(Vector distance)
        {
            throw new NotImplementedException();
        }

        public void Move(Vector newPosition)
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public void Accept(IVisitor visitor)
        {
            foreach (GodShape x in _components)
            {
                x.Accept(visitor);
            }
        }
    }
}
