using System;
using System.Collections.Generic;
using System.Text;
using PaintApp4Scrubs.Classes.Shapes;

namespace PaintApp4Scrubs.Classes
{
    class Boxer
    {
        private List<GodShape> childrenGodShapes = new List<GodShape>();

        public void Addchild(GodShape shape)
        { 
            childrenGodShapes.Add(shape);
        }

        public void Detach(GodShape shape)
        {
            childrenGodShapes.Remove(shape);
        }

        public List<GodShape> GetChildren()
        {
            return childrenGodShapes;
        }
        public void SaveFile(List<GodShape> childern = null, string indent = "", bool head = true)
        {
            if (head)
            {
                PrintToFile("Canvas");
                if (childrenGodShapes.Count > 1)
                {
                    PrintToFile($"Group {childrenGodShapes.Count}");
                }
                childern = childrenGodShapes;
            }
            indent += "=";
            foreach (var child in childern)
            {
                if (child.GetChildrenOfGodShapes().Count <= 0)
                {
                    PrintToFile($"{indent} {child.ToString()}");
                }
                else
                {
                    PrintToFile($"{indent} {child.ToString()}");
                    if (child.GetChildrenOfGodShapes().Count != 1)
                    {
                        PrintToFile($"{indent} Group {child.GetChildrenOfGodShapes().Count}");
                    }
                    this.SaveFile(child.GetChildrenOfGodShapes(), indent, false);
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
    }
}
