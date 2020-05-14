using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Strategies
{
    public class LineStrategies : IStrategy
    {
        private LineGeometry _lineGeometry = new LineGeometry();
        private Point _start = new Point(0, 0);
        private Point _end = new Point(0, 0);
        public double Height { get; set; }
        public double Width { get; set; }
        public LineStrategies(Point startPoint, Point endPoint)
        {
            startPoint.Y -= 50;
            endPoint.Y -= 50;
            StartPoint = startPoint;
            EndPoint = endPoint;
        }

        public Point StartPoint
        {
            get { return _start; }
            set
            {
                _start = value;
                _lineGeometry.StartPoint = value;
            }
        }
        
        public Point EndPoint
        {
            get { return _end; }
            set
            {
                _end = value;
                _lineGeometry.EndPoint = value;
            }
        }

        public Vector GetCenter(BaseShape baseShape)
        {
            var center = new Vector((Canvas.GetLeft(baseShape) + (this.Width / 2)), Canvas.GetTop(baseShape) + (this.Height / 2));
            return center;
        }

        public Geometry GetGeometry()
        {
            return _lineGeometry;
        }

        public string GetString(BaseShape baseShape)
        {
            throw new System.NotImplementedException();
        }

        public void Accept(IVisitor visitor, BaseShape baseShape)
        {
            visitor.VisitLine(baseShape);
        }
    }
}