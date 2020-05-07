using System;
using System.Collections.Generic;
using System.Text;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.VisitorCommands
{
    class VisitorDisplay : IVisitor
    {

        public void Visit(GodShape godShape)
        {
            godShape.Display();
        }
    }
}
