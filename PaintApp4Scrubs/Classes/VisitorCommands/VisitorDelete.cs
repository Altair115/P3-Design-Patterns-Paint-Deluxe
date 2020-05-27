using System.Windows;
using System.Windows.Controls;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.VisitorCommands
{
    /// <summary>
    /// Visitor to delete the objects
    /// </summary>
    public class VisitorDelete : IVisitor
    {

        /// <summary>
        /// Visitor Function for Boxer
        /// </summary>
        /// <param name="boxer">Selected Box</param>
        public void Visit(Boxer boxer)
        {
            foreach (var component in boxer.GetChildren())
            {
               component.Accept(this);
            }
        }

        /// <summary>
        /// Visitor Function for line
        /// </summary>
        /// <param name="line">Selected Shape</param>
        public void VisitLine(BaseShape line)
        {
            MainWindow.AppWindow.RemoveShape(line);
        }

        /// <summary>
        /// Visitor Function for square
        /// </summary>
        /// <param name="square">Selected Shape</param>
        public void VisitSquare(BaseShape square)
        {
            MainWindow.AppWindow.RemoveShape(square);
        }

        /// <summary>
        /// Visitor Function for triangle
        /// </summary>
        /// <param name="triangle">Selected Shape</param>
        public void VisitTriangle(BaseShape triangle)
        {
            MainWindow.AppWindow.RemoveShape(triangle);
        }

        /// <summary>
        /// Visitor Function for ellipse
        /// </summary>
        /// <param name="ellipse">Selected Shape</param>
        public void VisitEllipse(BaseShape ellipse)
        {
            MainWindow.AppWindow.RemoveShape(ellipse);
        }
        /// <summary>
        /// puts the ornament on the main window and calls the next ornament and at last the shape (go's from bottom to top so shape first)
        /// </summary>
        /// <param name="ornament">the given ornament</param>
        public void VisitOrnament(Ornament ornament)
        {
            ornament.GetComponent().Accept(this);
            MainWindow.AppWindow.RemoveShape(ornament.TextBlock);
        }
    }
}