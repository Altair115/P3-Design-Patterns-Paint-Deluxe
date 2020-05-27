using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Strategies
{
    /// <summary>
    /// triangle strategies
    /// </summary>
    public class TriangleStrategies : IStrategy
    {
        /// <summary>
        /// gets and sets the height of the Triangle
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// gets and sets the Width of the Triangle
        /// </summary>
        public double Width { get; set; }
        /// <summary>
        /// gets and sets the StartPoint of the Triangle
        /// </summary>
        public Point StartPoint { get; set; }
        /// <summary>
        /// gets and sets the EndPoint of the Triangle
        /// </summary>
        public Point EndPoint { get; set; }
        /// <summary>
        /// Triangle Strategies constructor
        /// </summary>
        /// <param name="width">width</param>
        /// <param name="height">height</param>
        public TriangleStrategies(double width, double height)
        {
            Height = height;
            Width = width;
        }
        /// <summary>
        /// gets the Geometry of a triangle 
        /// </summary>
        /// <returns>geometry</returns>
        public Geometry GetGeometry()
        {
            Point p1 = new Point(0.0d, 0.0d);
            Point p2 = new Point(this.Width, 0);
            Point p3 = new Point(this.Width / 2, this.Height);


            List<PathSegment> segments = new List<PathSegment>(3);
            segments.Add(new LineSegment(p1, true));
            segments.Add(new LineSegment(p2, true));
            segments.Add(new LineSegment(p3, true));

            List<PathFigure> figures = new List<PathFigure>(1);
            PathFigure pf = new PathFigure(p1, segments, true);
            figures.Add(pf);

            Geometry geometry = new PathGeometry(figures, FillRule.EvenOdd, null);

            return geometry;
        }
        /// <summary>
        /// returns the string of Triangle
        /// </summary>
        /// <param name="baseShape">the base shape</param>
        /// <returns>Returns the Triangle string Format</returns>
        public string GetString(BaseShape baseShape)
        {
            return $"Triangle {Canvas.GetLeft(baseShape)} {Canvas.GetTop(baseShape)} {Width} {Height}";
        }
        /// <summary>
        /// the visitor method for Triangle 
        /// </summary>
        /// <param name="visitor">the past visitor</param>
        /// <param name="baseShape">base shape</param>
        public void Accept(IVisitor visitor, BaseShape baseShape)
        {
            visitor.VisitTriangle(baseShape);
        }
        /// <summary>
        /// gets the center of triangle
        /// </summary>
        /// <param name="baseShape">the base shape</param>
        /// <returns>the center vector </returns>
        public Vector GetCenter(BaseShape baseShape)
        {
            var center = new Vector((Canvas.GetLeft(baseShape) + (this.Width / 2)), Canvas.GetTop(baseShape) + (this.Height / 2));
            return center;
        }
    }
}