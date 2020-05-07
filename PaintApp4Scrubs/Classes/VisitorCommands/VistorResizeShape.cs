using System;
using System.Collections.Generic;
using System.Text;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.VisitorCommands
{
    class VistorResizeShape : IVisitor
    {
        public void Visit(Boxer boxer)
        {
            throw new NotImplementedException();
        }

        public void Visit(GodShape godShape)
        {
            throw new NotImplementedException();
        }
    }
}
