using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Windows;
using PaintApp4Scrubs.Classes.Shapes;

namespace PaintApp4Scrubs.Classes
{
    public class Boxer : IComponent
    {
        private readonly List<IComponent> components = new List<IComponent>();
        private bool _isHead;

        public Boxer(bool head = false)
        {
            _isHead = head;
        }
        public void Add(IComponent component)
        { 
            components.Add(component);
        }

        public void Detach(IComponent component)
        {
            components.Remove(component);
        }
        public bool Equals(Boxer other)
        {
            return this == other;
        }
        public Boxer FindBox( GodShape shape, bool head = true)
        {
            foreach (var component in components)
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
            return components;
        }
        //public void SaveFile(List<GodShape> childern = null, string indent = "", bool head = true) 
        //{
        //    if (head)
        //    {
        //        PrintToFile("Canvas");
        //        if (childrenGodShapes.Count > 1)
        //        {
        //            PrintToFile($"Group {childrenGodShapes.Count}");
        //        }
        //        childern = childrenGodShapes;
        //    }
        //    indent += " ";
        //    foreach (var child in childern)
        //    {
        //        if (child.GetChildrenOfGodShapes().Count <= 0)
        //        {
        //            PrintToFile($"{indent} {child.ToString()}");
        //        }
        //        else
        //        {
        //            PrintToFile($"{indent} {child.ToString()}");
        //            if (child.GetChildrenOfGodShapes().Count != 1)
        //            {
        //                PrintToFile($"{indent} Group {child.GetChildrenOfGodShapes().Count}");
        //            }
        //            this.SaveFile(child.GetChildrenOfGodShapes(), indent, false);
        //        }
        //    }
        //}
        //public void ClearFile()
        //{
        //    System.IO.File.WriteAllText(@"..\..\..\..\savetest.txt", "");
        //}

        //public void PrintToFile(string text)
        //{
        //    using System.IO.StreamWriter file =
        //        new System.IO.StreamWriter(@"..\..\..\..\savetest.txt", true);
        //    file.WriteLine(text);
        //}

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
    }
}
