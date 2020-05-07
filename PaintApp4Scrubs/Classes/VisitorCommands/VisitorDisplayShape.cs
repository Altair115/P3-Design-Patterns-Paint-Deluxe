using System;
using System.Collections.Generic;
using System.Text;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.VisitorCommands
{
    class VisitorDisplayShape :IVisitor
    {
        public void VisitLine(Line line)
        {
            
        }

        public void VisitEllipse(Ellipse ellipse)
        {
           
        }

        public void VisitSquare(Square square)
        {
           
        }

        public void VisitTriangle(Triangle triangle)
        {
        }
    }
}
