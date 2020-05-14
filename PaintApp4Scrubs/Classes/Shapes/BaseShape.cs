using System.Windows;
using System.Windows.Media;
using PaintApp4Scrubs.Classes.Strategies;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Shapes
{
    public class BaseShape : GodShape, IAccept
    {
        public IStrategy strategy;
        public double StrategyWidth
        {
            get { return strategy.Width;}
            set { strategy.Width = value;}
        }

        public double StrategyHeight
        {
            get { return strategy.Height; }
            set { strategy.Height = value; }
        }

        public Point StartPoint
        {
            get { return strategy.StartPoint;}
            set { strategy.StartPoint = value;}
        }
        public Point EndPoint
        {
            get { return strategy.EndPoint; }
            set { strategy.EndPoint = value; }
        }
        public BaseShape(IStrategy s)
        {
            strategy = s;
        }
        public virtual void Accept(IVisitor visitor)
        {
            strategy.Accept(visitor,this);
        }
        protected override Geometry DefiningGeometry
        {
            get { return strategy.GetGeometry(); }

        }
        public override string ToString()
        {
            return strategy.GetString(this);
        }
    }
}