using System;
using System.Collections.Generic;
using System.Text;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;
using System.Windows;
using System.Windows.Media;

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

        public void Visit(Line line)
        {
            line.X2 -= _distance.X;
            line.Y2 -= _distance.Y;
            line.LineGeometry.EndPoint = line.EndPoint;
        }

        public void Visit(Square square)
        {
            if (!(square.Width > _distance.X) || !(square.Height > _distance.Y)) return;
            square.Width -= _distance.X;
            square.Height -= _distance.Y;
        }

        public void Visit(Triangle triangle)
        {
            if (!(triangle.Width > _distance.X) || !(triangle.Height > _distance.Y)) return;
            triangle.Width -= _distance.X;
            triangle.Height -= _distance.Y;
        }

        public void Visit(Ellipse ellipse)
        {
            if (!(ellipse.XRadius > _distance.X) || !(ellipse.YRadius > _distance.Y)) return;
            ellipse.XRadius -= _distance.X;
            ellipse.YRadius -= _distance.Y;
            ellipse.EllipseGeometry.RadiusX = ellipse.XRadius;
            ellipse.EllipseGeometry.RadiusY = ellipse.YRadius;
        }
    }
}
