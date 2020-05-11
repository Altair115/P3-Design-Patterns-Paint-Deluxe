using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

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
            foreach (var x in boxer.GetChildren())
            {
                if (x is Boxer)
                {
                    Visit(x as Boxer);
                }
                MainWindow.AppWindow.PutOnScreen(x as GodShape);
            }
        }

        public void Visit(Line line)
        {
            MainWindow.AppWindow.PutOnScreen(line);
        }

        public void Visit(Square square)
        {
            MainWindow.AppWindow.PutOnScreen(square);
        }

        public void Visit(Triangle triangle)
        {
            MainWindow.AppWindow.PutOnScreen(triangle);
        }

        public void Visit(Ellipse ellipse)
        {
            MainWindow.AppWindow.PutOnScreen(ellipse);
        }
    }
}