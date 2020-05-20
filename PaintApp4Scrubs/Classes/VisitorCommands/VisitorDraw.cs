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
            TextBlock textBlock = new TextBlock();
            //do stuff
            //textBlock.Text = ornament.Name.ToString();
            //sizeofTexBlock = MeasureString(Name);
            //Vector x = GetVector(PositionPlace);
            //Canvas.SetTop(textBlock, x.Y);
            //Canvas.SetLeft(textBlock, x.X);
            //MainWindow.AppWindow.PutOnScreen(textBlock);
            //ornament.getcomponent().accept(this);
        }
    }
}