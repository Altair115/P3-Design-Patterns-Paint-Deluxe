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
    }
}
