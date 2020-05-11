using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.VisitorCommands
{
    public class VisitorDraw : IVisitor
    {
        public void Visit(GodShape godShape)
        {
            godShape.Draw();
        }
        public void Visit(Boxer boxer)
        {

        }

        public void Visit(Line line)
        {

        }

        public void Visit(Square square)
        {

        }

        public void Visit(Triangle triangle)
        {

        }

        public void Visit(Ellipse ellipse)
        {

        }
    }
}