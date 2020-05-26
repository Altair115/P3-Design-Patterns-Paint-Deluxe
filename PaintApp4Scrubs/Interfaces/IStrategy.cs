using System.Windows;
using System.Windows.Media;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Strategies
{
    public interface IStrategy
    {
        /// <summary>
        /// gets the Geometry 
        /// </summary>
        /// <returns>Geometry</returns>
        public Geometry GetGeometry();
        /// <summary>
        /// gets and sets the Height
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// gets and sets the Width
        /// </summary>
        public double Width { get; set; }
        /// <summary>
        /// gets the string from the strategy 
        /// </summary>
        /// <param name="baseShape">the base shape</param>
        /// <returns>the string of the strategy </returns>
        public string GetString(BaseShape baseShape);
        /// <summary>
        /// this interacts with the visitor for the given strategy 
        /// </summary>
        /// <param name="visitor">the given visitor</param>
        /// <param name="baseShape">the base shape</param>
        public void Accept(IVisitor visitor, BaseShape baseShape);
        /// <summary>
        /// gets and sets the StartPoint
        /// </summary>
        public Point StartPoint { get; set; }
        /// <summary>
        /// gets and sets the Endpoint
        /// </summary>
        public Point EndPoint { get; set; }
        /// <summary>
        /// gets the Vector of the center of the Strategy 
        /// </summary>
        /// <param name="baseShape">base shape </param>
        /// <returns>the center vector </returns>
        public Vector GetCenter(BaseShape baseShape);
    }
}