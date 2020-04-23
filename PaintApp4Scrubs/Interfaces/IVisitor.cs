using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using PaintApp4Scrubs.Classes.Shapes;

namespace PaintApp4Scrubs.Interfaces
{
    public interface IVisitor
    {
        void VisitLine(Line line);
        void VisitEllipse(Ellipse ellipse);
        void VisitSquare(Square square);
        void VisitTriangle(Triangle triangle);

    }
}
