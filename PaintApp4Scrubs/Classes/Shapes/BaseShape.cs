using System.Windows;
using System.Windows.Media;
using PaintApp4Scrubs.Classes.Strategies;

namespace PaintApp4Scrubs.Classes.Shapes
{
    public class BaseShape : GodShape
    {
        private IStrategy _strategy;
        public double StrategyWidth
        {
            get { return _strategy.Width;}
            set { _strategy.Width = value;}
        }

        public double StrategyHeight
        {
            get { return _strategy.Height; }
            set { _strategy.Height = value; }
        }
        public BaseShape(IStrategy s)
        {
            _strategy = s;
        }
        protected override Geometry DefiningGeometry
        {
            get { return _strategy.GetGeometry(); }

        }
        public override string ToString()
        {
            return _strategy.GetString(this);
        }
    }
}