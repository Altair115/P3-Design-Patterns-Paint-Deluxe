using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using PaintApp4Scrubs.Classes;
using PaintApp4Scrubs.Classes.Shapes;

namespace PaintApp4Scrubs.Interfaces
{
    public interface IVisitor
    {
        public void Visit(GodShape godShape);
        public void Visit(Boxer boxer);
        public void Visit(Line line);
        public void Visit(Square square);
        public void Visit(Triangle triangle);
        public void Visit(Ellipse ellipse);
    }
}
