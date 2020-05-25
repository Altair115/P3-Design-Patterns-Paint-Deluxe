using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace PaintApp4Scrubs.Classes.VisitorCommands
{
    public class VisitorMove : IVisitor
    {
        public Vector TranslationToNewPosition { get; set; }

        /// <summary>
        /// VisitorMove Constructor
        /// </summary>
        /// <param name="translationToNewPosition">The translation vector to the new position</param>
        public VisitorMove(Vector translationToNewPosition)
        {
            TranslationToNewPosition = translationToNewPosition;
        }

        /// <summary>
        /// Visitor Function for godShape
        /// </summary>
        /// <param name="godShape">Selected Shape</param>
        public void Visit(GodShape godShape)
        {
          var x = godShape as BaseShape;
          x.Accept(this);
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
            var translation = Converter.ToPoint(TranslationToNewPosition);

            var lineStartPoint = line.StartPoint;
            var lineEndPoint = line.EndPoint;

            lineStartPoint.X = lineStartPoint.X - translation.X;
            lineStartPoint.Y = lineStartPoint.Y - translation.Y;

            lineEndPoint.X = lineEndPoint.X - translation.X;
            lineEndPoint.Y = lineEndPoint.Y - translation.Y;

            line.StartPoint = lineStartPoint;
            line.EndPoint = lineEndPoint;
        }

        /// <summary>
        /// Visitor Function for square
        /// </summary>
        /// <param name="square">Selected Shape</param>
        public void VisitSquare(BaseShape square)
        {
            square.OriginPos = square.GetCenter();
            Vector result = Vector.Subtract(square.OriginPos, TranslationToNewPosition);
            var left = result.X - (square.Width / 2);
            var top = result.Y - (square.Height / 2);
            Canvas.SetLeft(square, left);
            Canvas.SetTop(square, top);
        }

        /// <summary>
        /// Visitor Function for triangle
        /// </summary>
        /// <param name="triangle">Selected Shape</param>
        public void VisitTriangle(BaseShape triangle)
        {
            triangle.OriginPos = triangle.GetCenter();
            Vector result = Vector.Subtract(triangle.OriginPos, TranslationToNewPosition);
            var left = result.X - (triangle.Width / 2);
            var top = result.Y - (triangle.Height / 2);
            Canvas.SetLeft(triangle, left);
            Canvas.SetTop(triangle, top);
        }

        /// <summary>
        /// Visitor Function for ellipse
        /// </summary>
        /// <param name="ellipse">Selected Shape</param>
        public void VisitEllipse(BaseShape ellipse)
        {
            ellipse.OriginPos = ellipse.GetCenter();
            Vector result = Vector.Subtract(ellipse.OriginPos, TranslationToNewPosition);
            Canvas.SetLeft(ellipse, result.X);
            Canvas.SetTop(ellipse, result.Y);
        }
    }
}