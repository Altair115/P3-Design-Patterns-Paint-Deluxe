using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes
{
    public class Ornament : Decorator
    {
        public string Name = "";
        public string Position = "";
        private Size _sizeofTexBlock;
        public TextBlock TextBlock = new TextBlock();
        private string _depth;

        protected override Geometry DefiningGeometry
        {
            get
            {
                Point p1 = new Point(0.0d, 0.0d);
                Point p2 = new Point(0, 0);
                Point p3 = new Point(0, 0);
                Point p4 = new Point(0, 0.0d);

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
        }

        public Ornament(GodShape godShape) : base(godShape)
        {
        }

        public Vector GetVector(string position)
        {
            Vector center = GetCenter();
            _sizeofTexBlock = MeasureString(Name);
            switch (position)
            {
                case "left":
                    //TextBlock.FlowDirection = FlowDirection.RightToLeft;
                    return new Vector(center.X - (StrategyWidth / 2) - _sizeofTexBlock.Width - 20, center.Y - (_sizeofTexBlock.Height / 2));
                case "right":
                    return new Vector(center.X + (StrategyWidth / 2) + 20, center.Y - (_sizeofTexBlock.Height / 2));
                case "top":
                    return new Vector(center.X - (_sizeofTexBlock.Width / 2), center.Y - (StrategyHeight / 2) - (_sizeofTexBlock.Height * 2));
                case "bottom":
                    return new Vector(center.X - (_sizeofTexBlock.Width / 2), center.Y + (StrategyHeight / 2) + (_sizeofTexBlock.Height / 2));
                default:
                    return new Vector(0, 0);
            }
        }

        private Size MeasureString(string candidate)
        {
            var formattedText = new FormattedText(
                candidate,
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface(this.TextBlock.FontFamily, this.TextBlock.FontStyle, this.TextBlock.FontWeight,
                    this.TextBlock.FontStretch),
                this.TextBlock.FontSize,
                Brushes.Black,
                new NumberSubstitution(),
                1);

            return new Size(formattedText.Width, formattedText.Height);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitOrnament(this);
        }

        public override string Depth
        {
            get => _depth;
            set
            {
                _depth = value;
                base.Depth = value;
            }
        }

        public override double StrategyHeight
        {
            get => base.StrategyHeight;
            set { }
        }

        public override double StrategyWidth
        {
            get => base.StrategyWidth;
            set { }
        }

        public override string ToString()
        {
            return $"ornament {Position} {Name}";
        }
    }
}