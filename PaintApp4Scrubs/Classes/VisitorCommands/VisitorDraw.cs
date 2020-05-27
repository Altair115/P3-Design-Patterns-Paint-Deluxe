using System.Windows.Controls;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;
using System.Windows;
namespace PaintApp4Scrubs.Classes.VisitorCommands
{
    /// <summary>
    /// Visitor for Drawing Shapes
    /// </summary>
    public class VisitorDraw : IVisitor
    {
        /// <summary>
        /// Visitor Function for boxer
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
            MainWindow.AppWindow.PutOnScreen(line);
        }

        /// <summary>
        /// Visitor Function for square
        /// </summary>
        /// <param name="square">Selected Shape</param>
        public void VisitSquare(BaseShape square)
        {
            MainWindow.AppWindow.PutOnScreen(square);
        }

        /// <summary>
        /// Visitor Function for triangle
        /// </summary>
        /// <param name="triangle">Selected Shape</param>
        public void VisitTriangle(BaseShape triangle)
        {
            MainWindow.AppWindow.PutOnScreen(triangle);
        }

        /// <summary>
        /// Visitor Function for ellipse
        /// </summary>
        /// <param name="ellipse">Selected Shape</param>
        public void VisitEllipse(BaseShape ellipse)
        {
            MainWindow.AppWindow.PutOnScreen(ellipse);
        }

        public void VisitOrnament(Ornament ornament)
        {
            ornament.TextBlock.Text = ornament.Name.ToString();
            Vector x = ornament.GetVector(ornament.Position);
            Canvas.SetTop(ornament.TextBlock,x.Y);
            Canvas.SetLeft(ornament.TextBlock,x.X);
            ornament.GetComponent().Accept(this);
            MainWindow.AppWindow.PutOnScreen(ornament.TextBlock);
        }
    }
}