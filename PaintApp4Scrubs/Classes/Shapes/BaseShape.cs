using System.Windows;
using System.Windows.Media;
using PaintApp4Scrubs.Classes.Strategies;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Shapes
{
    /// <summary>
    /// The Base Shape where all shapes are equal ("hail communism" ) https://www.youtube.com/watch?v=BulFwGSi8bc
    /// </summary>
    public class BaseShape : GodShape, IAccept
    {
        public IStrategy Strategy;
        /// <summary>
        /// set and gets the Strategy related Width
        /// </summary>
        public double StrategyWidth
        {
            get { return Strategy.Width;}
            set { Strategy.Width = value;}
        }
        /// <summary>
        /// set and gets the Strategy related Height
        /// </summary>
        public double StrategyHeight
        {
            get { return Strategy.Height; }
            set { Strategy.Height = value; }
        }

        /// <summary>
        /// set and gets the Strategy related StartPoint
        /// </summary>
        public Point StartPoint
        {
            get { return Strategy.StartPoint;}
            set { Strategy.StartPoint = value;}
        }

        /// <summary>
        /// set and gets the Strategy related EndPoint
        /// </summary>
        public Point EndPoint
        {
            get { return Strategy.EndPoint; }
            set { Strategy.EndPoint = value; }
        }
        /// <summary>
        /// the constructor of BaseShape
        /// </summary>
        /// <param name="s">the selected Strategy </param>
        public BaseShape(IStrategy s)
        {
            Strategy = s;
        }
        /// <summary>
        /// The Visitor Accept Method for the selected strategy
        /// </summary>
        /// <param name="visitor">the selected visitor</param>
        public virtual void Accept(IVisitor visitor)
        {
            Strategy.Accept(visitor,this);
        }

        /// <summary>
        /// defines the geometry of the shape with the strategy 
        /// </summary>
        protected override Geometry DefiningGeometry
        {
            get { return Strategy.GetGeometry(); }

        }
        /// <summary>
        /// the string of the strategy 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Strategy.GetString(this);
        }

        public Vector GetCenter()
        {
            return Strategy.GetCenter(this);
        }
    }
}