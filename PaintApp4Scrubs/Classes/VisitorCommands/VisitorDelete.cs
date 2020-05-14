using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.VisitorCommands
{
    public class VisitorDelete : IVisitor
    {
        public void Visit(GodShape godShape)
        {
            MainWindow.AppWindow.RemoveShape(godShape);
        }
        public void Visit(Boxer boxer)
        {
            foreach (var x in boxer.GetChildren())
            {
                if (x is Boxer)
                {
                    Visit(x as Boxer);
                }
                MainWindow.AppWindow.RemoveShape(x as GodShape);
            }
        }

        public void VisitLine(BaseShape line)
        {
            MainWindow.AppWindow.RemoveShape(line);
        }

        public void VisitSquare(BaseShape square)
        {
            MainWindow.AppWindow.RemoveShape(square);
        }

        public void VisitTriangle(BaseShape triangle)
        {
            MainWindow.AppWindow.RemoveShape(triangle);
        }

        //public void Visit(Line line)
        //{
        //    MainWindow.AppWindow.RemoveShape(line);
        //}

        //public void Visit(Square square)
        //{
        //    MainWindow.AppWindow.RemoveShape(square);
        //}

        //public void Visit(Triangle triangle)
        //{
        //    MainWindow.AppWindow.RemoveShape(triangle);
        //}

        //public void Visit(Ellipse ellipse)
        //{
        //    MainWindow.AppWindow.RemoveShape(ellipse);
        //}

        public void VisitEllipse(BaseShape ellipseBaseShape)
        {
            MainWindow.AppWindow.RemoveShape(ellipseBaseShape);
        }
    }
}