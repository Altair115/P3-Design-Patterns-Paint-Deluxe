using System.Windows;
using System.Windows.Media;
using Microsoft.VisualBasic.CompilerServices;
using PaintApp4Scrubs.Classes.Strategies;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Shapes
{
    /// <summary>
    /// The Base Shape where all shapes are equal ("hail communism" ) https://www.youtube.com/watch?v=BulFwGSi8bc
    /// </summary>
    public class BaseShape : GodShape, IAccept
    {
        private string _depth;
        public bool HasDeco = false;
        public IStrategy Strategy;
        /// <summary>
        /// set and gets the Strategy related Width
        /// </summary>
        public override double StrategyWidth
        {
            get => Strategy.Width;
            set => Strategy.Width = value;
        }
        /// <summary>
        /// set and gets the Strategy related Height
        /// </summary>
        public override double StrategyHeight
        {
            get => Strategy.Height;
            set => Strategy.Height = value;
        }

        /// <summary>
        /// set and gets the Strategy related StartPoint
        /// </summary>
        public Point StartPoint
        {
            get => Strategy.StartPoint;
            set => Strategy.StartPoint = value;
        }

        /// <summary>
        /// set and gets the Strategy related EndPoint
        /// </summary>
        public Point EndPoint
        {
            get => Strategy.EndPoint;
            set => Strategy.EndPoint = value;
        }
        /// <summary>
        /// the constructor of BaseShape
        /// </summary>
        /// <param name="s">the selected Strategy </param>
        public BaseShape(IStrategy s)
        {
            Strategy = s;
        }
        
        public override GodShape GetBaseShape()
        {
            return this;
        }

        /// <summary>
        /// The Visitor Accept Method for the selected strategy
        /// </summary>
        /// <param name="visitor">the selected visitor</param>
        public override void Accept(IVisitor visitor)
        {
            Strategy.Accept(visitor,this);
        }

        /// <summary>
        /// defines the geometry of the shape with the strategy 
        /// </summary>
        protected override Geometry DefiningGeometry => Strategy.GetGeometry();

        /// <summary>
        /// the string of the strategy 
        /// </summary>
        /// <returns>The String Format</returns>
        public override string ToString()
        {
            return Strategy.GetString(this);
        }

        /// <summary>
        /// get the center of the given shape by the strategy 
        /// </summary>
        /// <returns>the center vector</returns>
        public override Vector GetCenter()
        {
            return Strategy.GetCenter(this);
        }
        /// <summary>
        /// gets and sets the Depth of the object
        /// </summary>
        public override string Depth
        {
            get => _depth;
            set
            {
                if (HasDeco)
                    _depth = value + "-";
                else 
                    _depth = value;
            } 
        }
    }
}