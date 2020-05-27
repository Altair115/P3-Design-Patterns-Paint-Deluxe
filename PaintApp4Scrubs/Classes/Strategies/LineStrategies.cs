using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Strategies
{

    /// <summary>
    /// the strategy for the line
    /// </summary>
    public class LineStrategies : IStrategy
    {
        private readonly LineGeometry _lineGeometry = new LineGeometry();
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
        /// <summary>
        /// gets and sets the StartPoint of the line and the LineGeometry
        /// </summary>
        public Point StartPoint
        {
            get => _start;
            set
            {
                _start = value;
                _lineGeometry.StartPoint = value;
            }
        }
        /// <summary>
        /// gets and sets the EndPoint of the line and the lineGeometry
        /// </summary>
        public Point EndPoint
        {
            get => _end;
            set
            {
                _end = value;
                _lineGeometry.EndPoint = value;
            }
        }

        /// <summary>
        /// Gets the Center of the line
        /// </summary>
        /// <param name="baseShape">the base shape</param>
        /// <returns>the center vector </returns>
        public Vector GetCenter(BaseShape baseShape)
        {
            var center = new Vector((StartPoint.X + EndPoint.X) / 2, (StartPoint.Y + EndPoint.Y) / 2);
            return center;
        }
        /// <summary>
        /// gets the lineGeometry
        /// </summary>
        /// <returns>line geometry </returns>
        public Geometry GetGeometry()
        {
            return _lineGeometry;
        }
        /// <summary>
        /// gets the string of the Line
        /// </summary>
        /// <param name="baseShape"></param>
        /// <returns>the line his string</returns>
        public string GetString(BaseShape baseShape)
        {
            return $"Line {GetCenter(baseShape)} {StartPoint} {EndPoint}";
        }

        /// <summary>
        /// The accept method for the line 
        /// </summary>
        /// <param name="visitor">the type of visitor given</param>
        /// <param name="baseShape">the base shape</param>
        public void Accept(IVisitor visitor, BaseShape baseShape)
        {
            visitor.VisitLine(baseShape);
        }
    }
}