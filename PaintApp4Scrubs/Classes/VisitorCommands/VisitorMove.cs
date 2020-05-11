using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;
using System.Windows;

namespace PaintApp4Scrubs.Classes.VisitorCommands
{
    public class VisitorMove : IVisitor
    {
        public Vector NewPosition { get; set; }
        public VisitorMove(Vector newPosition)
        {
            NewPosition = newPosition;
        }

        public void Visit(GodShape godShape)
        {
            godShape.Move(NewPosition);
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