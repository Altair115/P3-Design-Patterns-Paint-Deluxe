using System.Windows.Controls;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;
using System.Windows;
namespace PaintApp4Scrubs.Classes.VisitorCommands
{
    public class VisitorDraw : IVisitor
    {
        public void Visit(GodShape godShape)
        {
            MainWindow.AppWindow.PutOnScreen(godShape);
        }
        public void Visit(Boxer boxer)
        {
            foreach (var component in boxer.GetChildren())
            {
                component.Accept(this);
            }
        }

        public void VisitLine(BaseShape line)
        {
            MainWindow.AppWindow.PutOnScreen(line);
        }

        public void VisitSquare(BaseShape square)
        {
            MainWindow.AppWindow.PutOnScreen(square);
        }

        public void VisitTriangle(BaseShape triangle)
        {
            MainWindow.AppWindow.PutOnScreen(triangle);
        }

        public void VisitEllipse(BaseShape ellipseBaseShape)
        {
            MainWindow.AppWindow.PutOnScreen(ellipseBaseShape);
        }

        public void VisitOrnament(Ornament ornament)
        {
            ornament.textBlock.Text = ornament.Name.ToString();
            Vector x = ornament.GetVector(ornament.Position);
            Canvas.SetTop(ornament.textBlock,x.Y);
            Canvas.SetLeft(ornament.textBlock,x.X);
            ornament.GetComponent().Accept(this);
            MainWindow.AppWindow.PutOnScreen(ornament.textBlock);
        }
    }
}