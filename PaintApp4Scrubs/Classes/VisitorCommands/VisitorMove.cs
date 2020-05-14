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
            godShape.OriginPos = godShape.GetCenter();
            Vector result = Vector.Subtract(godShape.OriginPos, TranslationToNewPosition);
            var left = result.X - (godShape.Width / 2);
            var top = result.Y - (godShape.Height / 2);
            Canvas.SetLeft(godShape, left);
            Canvas.SetTop(godShape, top);
        }
        public void Visit(Boxer boxer)
        {
            foreach (var x in boxer.GetChildren())
            {
                switch (x)
                {
                    case Boxer b:
                        Visit(x as Boxer);
                        break;
                    case Line l:
                        Visit(x as Line);
                        break;
                    case Square s:
                        Visit(x as Square);
                        break;
                    case Triangle t:
                        Visit(x as Triangle);
                        break;
                    case Ellipse e:
                        Visit(x as Ellipse);
                        break;
                }
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

        //public void Visit(Line line)
        //{
        //    var translation = Converter.ToPoint(TranslationToNewPosition);

        //    var lineStartPoint = line.StartPoint;
        //    var lineEndPoint = line.EndPoint;

        //    lineStartPoint.X = lineStartPoint.X - translation.X;
        //    lineStartPoint.Y = lineStartPoint.Y - translation.Y;

        //    lineEndPoint.X = lineEndPoint.X - translation.X;
        //    lineEndPoint.Y = lineEndPoint.Y - translation.Y;

        //    line.StartPoint = lineStartPoint;
        //    line.EndPoint = lineEndPoint;

        //    line.LineGeometry.StartPoint = line.StartPoint;
        //    line.LineGeometry.EndPoint = line.EndPoint;
        //}

        //public void Visit(Square square)
        //{
        //    square.OriginPos = square.GetCenter();
        //    Vector result = Vector.Subtract(square.OriginPos, TranslationToNewPosition);
        //    var left = result.X - (square.Width / 2);
        //    var top = result.Y - (square.Height / 2);
        //    Canvas.SetLeft(square, left);
        //    Canvas.SetTop(square, top);
        //}

        //public void Visit(Triangle triangle)
        //{
        //    //triangle.OriginPos = triangle.GetCenter();
        //    //Vector result = Vector.Subtract(triangle.OriginPos, TranslationToNewPosition);
        //    //var left = result.X - (triangle.Width / 2);
        //    //var top = result.Y - (triangle.Height / 2);
        //    //Canvas.SetLeft(triangle, left);
        //    //Canvas.SetTop(triangle, top);
        //}

        //public void Visit(Ellipse ellipse)
        //{
        //    ellipse.OriginPos = ellipse.GetCenter();
        //    Vector result = Vector.Subtract(ellipse.OriginPos, TranslationToNewPosition);
        //    Canvas.SetLeft(ellipse, result.X);
        //    Canvas.SetTop(ellipse, result.Y);
        //}

        public void VisitEllipse(BaseShape ellipseBaseShape)
        {
            ellipseBaseShape.OriginPos = ellipseBaseShape.GetCenter();
            Vector result = Vector.Subtract(ellipseBaseShape.OriginPos, TranslationToNewPosition);
            Canvas.SetLeft(ellipseBaseShape, result.X);
            Canvas.SetTop(ellipseBaseShape, result.Y);
        }
    }
}