using System;
using System.Collections.Generic;
using System.Text;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;
using System.Windows;

namespace PaintApp4Scrubs.Classes.VisitorCommands
{
    class VistorResize : IVisitor
    {
        private Vector _distance;
        public VistorResize (Vector distance)
        {
            _distance = distance;
        }

        public void Visit(GodShape godShape)
        {
            godShape.Resize(_distance);
        }
    }
}
