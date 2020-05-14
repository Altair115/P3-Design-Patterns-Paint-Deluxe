using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace PaintApp4Scrubs.Classes.VisitorCommands
{
    public class VisitorMove : IVisitor
    {
        public Vector TranslationToNewPosition { get; set; }
        public VisitorMove(Vector translationToNewPosition)
        {
            TranslationToNewPosition = translationToNewPosition;
        }

        public void Visit(GodShape godShape)
        {
          var x = godShape as BaseShape;
          x.Accept(this);
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

        public void VisitSquare(BaseShape square)
        {
            square.OriginPos = square.GetCenter();
            Vector result = Vector.Subtract(square.OriginPos, TranslationToNewPosition);
            var left = result.X - (square.Width / 2);
            var top = result.Y - (square.Height / 2);
            Canvas.SetLeft(square, left);
            Canvas.SetTop(square, top);
        }

        public void VisitTriangle(BaseShape triangle)
        {
            triangle.OriginPos = triangle.GetCenter();
            Vector result = Vector.Subtract(triangle.OriginPos, TranslationToNewPosition);
            var left = result.X - (triangle.Width / 2);
            var top = result.Y - (triangle.Height / 2);
            Canvas.SetLeft(triangle, left);
            Canvas.SetTop(triangle, top);
        }

        public void VisitEllipse(BaseShape ellipseBaseShape)
        {
            ellipseBaseShape.OriginPos = ellipseBaseShape.GetCenter();
            Vector result = Vector.Subtract(ellipseBaseShape.OriginPos, TranslationToNewPosition);
            Canvas.SetLeft(ellipseBaseShape, result.X);
            Canvas.SetTop(ellipseBaseShape, result.Y);
        }
    }
}