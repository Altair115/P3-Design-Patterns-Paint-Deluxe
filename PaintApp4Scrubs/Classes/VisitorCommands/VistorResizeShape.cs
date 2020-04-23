using System;
using System.Collections.Generic;
using System.Text;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.VisitorCommands
{
    class VistorResizeShape : IVisitor
    {
        public void VisitLine(Line line)
        {
            throw new NotImplementedException();//resize shit
        }

        public void VisitEllipse(Ellipse ellipse)
        {
            throw new NotImplementedException();
        }

        public void VisitSquare(Square square)
        {
            throw new NotImplementedException();
        }

        public void VisitTriangle(Triangle triangle)
        {
            throw new NotImplementedException();
        }
    }
}
