using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;
using System.Windows;

namespace PaintApp4Scrubs.Classes.VisitorCommands
{
    public class VisitorMove : IVisitor
    {
        public Vector NewPosition { get; set; }
        public Vector OldPosition { get; set; }
        public VisitorMove(Vector newPosition)
        {
            NewPosition = newPosition;

        }

        public void Visit(GodShape godShape)
        {
           OldPosition = godShape.GetCenter();
            godShape.Move(NewPosition);

        }
    }
}