using System;
using System.Collections.Generic;
using System.Text;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;
using System.Windows;

namespace PaintApp4Scrubs.Classes.VisitorCommands
{
    class VisitorResize : IVisitor
    {
        private Vector _distance;
        public VisitorResize (Vector distance)
        {
            _distance = distance;
        }

        public void Visit(GodShape godShape)
        {
            godShape.Resize(_distance);
        }
    }
}
