using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Strategies
{
    /// <summary>
    /// the strategy of The Ellipse Shape
    /// </summary>
    public class EllipseStrategies : IStrategy
    {
        public EllipseGeometry EllipseGeometry = new EllipseGeometry();
        private double _xRadius;
        private double _yRadius;

        /// <summary>
        /// the constructor of the EllipseStrategy
        /// </summary>
        /// <param name="xRadius">the x radius</param>
        /// <param name="yRadius">the y radius</param>
        public EllipseStrategies(double xRadius, double yRadius)
        {
            _yRadius = yRadius;
            _xRadius = xRadius;
        }
        /// <summary>
        /// set the geometry for an Ellipse Shape
        /// </summary>
        /// <returns>Ellipse Geometry</returns>
        public Geometry GetGeometry()
        {
            EllipseGeometry.RadiusX = Width;
            EllipseGeometry.RadiusY = Height;
            return EllipseGeometry;
        }
        /// <summary>
        /// the Height of the Ellipse
        /// </summary>
        public double Height
        {
            get { return _yRadius;}
            set { EllipseGeometry.RadiusY = value;
                _yRadius = value;
            }
        }
        /// <summary>
        /// The Width of the Ellipse
        /// </summary>
        public double Width
        {
            get { return _xRadius;}
            set { EllipseGeometry.RadiusX = value; _xRadius = value;
            }
        }
        /// <summary>
        /// gets the string of the Ellipse
        /// </summary>
        /// <param name="baseShape">the baseShape</param>
        /// <returns></returns>
        public string GetString(BaseShape baseShape)
        {
            return $"Ellipse {Canvas.GetLeft(baseShape)} {Canvas.GetTop(baseShape)} {_xRadius} {_yRadius}";
        }

        /// <summary>
        /// Accept Method to interact with the visitor 
        /// </summary>
        /// <param name="visitor">the given visitor</param>
        /// <param name="baseShape">the baseShape</param>
        public void Accept(IVisitor visitor, BaseShape baseShape)
        {
            visitor.VisitEllipse(baseShape);
        }
        /// <summary>
        /// gets and sets the Start point 
        /// </summary>
        public Point StartPoint { get; set; }
        /// <summary>
        /// gets and sets the End point 
        /// </summary>
        public Point EndPoint { get; set; }
        
        /// <summary>
        /// get the Center of the ellipse
        /// </summary>
        /// <param name="baseShape">the baseShape</param>
        /// <returns>the center vector</returns>
        public Vector GetCenter(BaseShape baseShape)
        {
            var center = new Vector(Canvas.GetLeft(baseShape), Canvas.GetTop(baseShape));
            return center;
        }
    }
}