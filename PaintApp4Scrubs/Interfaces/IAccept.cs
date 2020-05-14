using PaintApp4Scrubs.Classes.Shapes;

namespace PaintApp4Scrubs.Interfaces
{
    public interface IAccept
    {
        public void Accept(IVisitor visitor);
    }
}