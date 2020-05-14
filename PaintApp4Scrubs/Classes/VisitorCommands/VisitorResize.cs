using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;
using System.Windows;
using PaintApp4Scrubs.Classes.Strategies;

namespace PaintApp4Scrubs.Classes.VisitorCommands
{
    class VisitorResize : IVisitor
    {
        private Vector _distance;
        public VisitorResize (Vector distance)
        {
            _distance = distance;
        }

        public void Visit(GodShape godShape)
        {
            if (!(godShape.Width > _distance.X) || !(godShape.Height > _distance.Y)) return;
            godShape.Width -= _distance.X;
            godShape.Height -= _distance.Y;
        }
        public void Visit(Boxer boxer)
        {
            foreach (var x in boxer.GetChildren())
            {
                switch (x)
                {
                    case Boxer b:
                        Visit(b);
                        break;
                    
                }
            }
        }

        public void VisitLine(BaseShape line)
        {
            line.EndPoint -= _distance;
        }

        public void VisitSquare(BaseShape square)
        {
            if (!(square.StrategyWidth > _distance.X) || !(square.StrategyHeight > _distance.Y)) return;
            square.StrategyWidth -= _distance.X;
            square.StrategyHeight -= _distance.Y;
            square.Width -= _distance.X;
            square.Height -= _distance.Y;
        }

        public void VisitTriangle(BaseShape triangle)
        {
            if (!(triangle.StrategyWidth > _distance.X) || !(triangle.StrategyHeight > _distance.Y)) return;
            triangle.StrategyWidth -= _distance.X;
            triangle.StrategyHeight -= _distance.Y;
            triangle.Width -= _distance.X;
            triangle.Height -= _distance.Y;
        }

        public void VisitEllipse(BaseShape ellipseBaseShape)
        {
            if (!(ellipseBaseShape.StrategyWidth > _distance.X) || !(ellipseBaseShape.StrategyHeight > _distance.Y)) return;
            ellipseBaseShape.StrategyWidth -= _distance.X;
            ellipseBaseShape.StrategyHeight -= _distance.Y;
        }
    }
}
