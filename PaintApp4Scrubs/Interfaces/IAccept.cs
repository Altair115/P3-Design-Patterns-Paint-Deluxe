using PaintApp4Scrubs.Classes.Shapes;

namespace PaintApp4Scrubs.Interfaces
{
    public interface IAccept
    {
        /// <summary>
        /// Accepts a visitor
        /// </summary>
        /// <param name="visitor">the Visitor in question</param>
        public void Accept(IVisitor visitor);
    }
}