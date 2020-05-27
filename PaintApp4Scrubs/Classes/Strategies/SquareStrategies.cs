using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Strategies
{
    /// <summary>
    /// the square strategies
    /// </summary>
    public class SquareStrategies : IStrategy
    {
        /// <summary>
        /// gets and sets the height of the square
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// gets and sets the Width of the square
        /// </summary>
        public double Width { get; set; }
        /// <summary>
        /// gets and sets the StartPoint of the square
        /// </summary>
        public Point StartPoint { get; set; }
        /// <summary>
        /// gets and sets the EndPoint of the square
        /// </summary>
        public Point EndPoint { get; set; }
        /// <summary>
        /// the constructor of SquareStrategies 
        /// </summary>
        /// <param name="width">width</param>
        /// <param name="height">height</param>
        public SquareStrategies(double width,double height)
        {
            Height = height;
            Width = width;
        }
        /// <summary>
        /// gets the square Geometry 
        /// </summary>
        /// <returns>the square geometry</returns>
        public Geometry GetGeometry()
        {
            Point p1 = new Point(0.0d, 0.0d);
            Point p2 = new Point(0, Height);
            Point p3 = new Point(Width, Height);
            Point p4 = new Point(Width, 0.0d);

            List<PathSegment> segments = new List<PathSegment>(3);
            segments.Add(new LineSegment(p1, true));
            segments.Add(new LineSegment(p2, true));
            segments.Add(new LineSegment(p3, true));
            segments.Add(new LineSegment(p4, true));

            List<PathFigure> figures = new List<PathFigure>(1);
            PathFigure pf = new PathFigure(p1, segments, true);
            figures.Add(pf);

            Geometry geometry = new PathGeometry(figures, FillRule.EvenOdd, null);
            return geometry;
        }
        /// <summary>
        /// gets the string of the square
        /// </summary>
        /// <param name="baseShape">base shape</param>
        /// <returns>the string of square</returns>
        public string GetString(BaseShape baseShape)
        {
            return $"Rectangle {Canvas.GetLeft(baseShape)} {Canvas.GetTop(baseShape)} {Width} {Height}";
        }
        /// <summary>
        /// visit the vistor with square
        /// </summary>
        /// <param name="visitor">the past visitor </param>
        /// <param name="baseShape">base shape</param>
        public void Accept(IVisitor visitor, BaseShape baseShape)
        {
            visitor.VisitSquare(baseShape);
        }
        /// <summary>
        /// gets the center of the square
        /// </summary>
        /// <param name="baseShape">base shape</param>
        /// <returns>vector of square</returns>
        public Vector GetCenter(BaseShape baseShape)
        {
            var center = new Vector((Canvas.GetLeft(baseShape) + (this.Width / 2)), Canvas.GetTop(baseShape) + (this.Height / 2));
            return center;
        }
    }
}