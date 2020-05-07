using System;
using System.Collections.Generic;
using System.Text;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.VisitorCommands
{
    class VisitorDisplayShape : IVisitor
    {
        public void Visit(Boxer boxer)
        {
            //DO THIS OR EXECUTE THIS
            boxer.Display();
            //if (head)
            //{
            //    PrintToFile("Canvas");
            //    if (_components.Count > 1)
            //    {
            //        PrintToFile($"Group {_components.Count}");
            //    }
            //    children = _components;
            //}
            //indent += " ";
            //foreach (var child in children)
            //{
            //    if (child is GodShape)
            //    {
            //        PrintToFile($"{indent} {child.ToString()}");
            //    }
            //    else
            //    {
            //        var x = (Boxer)child;
            //        if (x.GetChildren().Count != 1)
            //        {
            //            PrintToFile($"{indent} Group {x.GetChildren().Count}");
            //        }
            //        this.Display(x.GetChildren(), indent, false);
            //    }
            //}
        }

        public void Visit(GodShape godShape)
        {
            //DO THIS OR EXECUTE THIS
            godShape.Display();
            //PrintToFile(this.ToString());
        }
    }
}
