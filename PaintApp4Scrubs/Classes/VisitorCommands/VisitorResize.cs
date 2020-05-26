using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;
using System.Windows;
using System.Windows.Controls;
using PaintApp4Scrubs.Classes.Strategies;

namespace PaintApp4Scrubs.Classes.VisitorCommands
{
    class VisitorResize : IVisitor
    {
        private Vector _distance;

        /// <summary>
        /// VisitorResize Constructor
        /// </summary>
        /// <param name="distance"></param>
        public VisitorResize (Vector distance)
        {
            _distance = distance;
        }

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
            line.EndPoint -= _distance;
        }

        /// <summary>
        /// Visitor Function for square
        /// </summary>
        /// <param name="square">Selected Shape</param>
        public void VisitSquare(BaseShape square)
        {
            if (!(square.StrategyWidth > _distance.X) || !(square.StrategyHeight > _distance.Y)) return;
            square.StrategyWidth -= _distance.X;
            square.StrategyHeight -= _distance.Y;
            square.Width -= _distance.X;
            square.Height -= _distance.Y;
        }

        /// <summary>
        /// Visitor Function for triangle
        /// </summary>
        /// <param name="triangle">Selected Shape</param>
        public void VisitTriangle(BaseShape triangle)
        {
            if (!(triangle.StrategyWidth > _distance.X) || !(triangle.StrategyHeight > _distance.Y)) return;
            triangle.StrategyWidth -= _distance.X;
            triangle.StrategyHeight -= _distance.Y;
            triangle.Width -= _distance.X;
            triangle.Height -= _distance.Y;
        }

        /// <summary>
        /// Visitor Function for ellipse
        /// </summary>
        /// <param name="ellipse">Selected Shape</param>
        public void VisitEllipse(BaseShape ellipse)
        {
            if (!(ellipse.StrategyWidth > _distance.X) || !(ellipse.StrategyHeight > _distance.Y)) return;
            ellipse.StrategyWidth -= _distance.X;
            ellipse.StrategyHeight -= _distance.Y;
        }

        public void VisitOrnament(Ornament ornament)
        {
            ornament.GetComponent().Accept(this);
            Vector x = ornament.GetVector(ornament.Position);
            Canvas.SetTop(ornament.TextBlock, x.Y);
            Canvas.SetLeft(ornament.TextBlock, x.X);
        }
    }
}
