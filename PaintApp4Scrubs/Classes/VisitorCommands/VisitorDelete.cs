using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.VisitorCommands
{
    public class VisitorDelete : IVisitor
    {
        public void Visit(GodShape godShape)
        {
            godShape.Remove();
        }
    }
}