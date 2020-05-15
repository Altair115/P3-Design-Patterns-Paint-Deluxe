using System.Windows;
using System.Windows.Media;
using PaintApp4Scrubs.Classes.Strategies;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Shapes
{
    public class BaseShape : GodShape, IAccept
    {
        public IStrategy Strategy;
        public double StrategyWidth
        {
            get { return Strategy.Width;}
            set { Strategy.Width = value;}
        }
        public double StrategyHeight
        {
            get { return Strategy.Height; }
            set { Strategy.Height = value; }
        }
        public Point StartPoint
        {
            get { return Strategy.StartPoint;}
            set { Strategy.StartPoint = value;}
        }
        public Point EndPoint
        {
            get { return Strategy.EndPoint; }
            set { Strategy.EndPoint = value; }
        }
        public BaseShape(IStrategy s)
        {
            Strategy = s;
        }

        public override void Decorate()
        {
            //Imagine that this just works
            //else just ask W. Brinksma
        }

        public virtual void Accept(IVisitor visitor)
        {
            Strategy.Accept(visitor,this);
        }
        protected override Geometry DefiningGeometry
        {
            get { return Strategy.GetGeometry(); }

        }
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