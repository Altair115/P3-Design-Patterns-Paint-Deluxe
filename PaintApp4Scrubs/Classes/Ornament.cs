﻿using System.Collections.Generic;
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
        public string PositionPlace = "";
        public Vector OrnamentPos;
        private double width = 0;
        private double height = 0;
        private double offset = 50;
        private Size sizeofTexBlock;
        public TextBlock textBlock = new TextBlock();

        protected override Geometry DefiningGeometry
        {
            get
            {
                Point p1 = new Point(0.0d, 0.0d);
                Point p2 = new Point(0, 10);
                Point p3 = new Point(10, 10);
                Point p4 = new Point(10, 0.0d);

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

        public override void Decorate()
        {
            //base.Decorate();
            ////do stuff
            //textBlock.Text = Name.ToString();
            //sizeofTexBlock = MeasureString(Name);
            //Vector x = GetVector(PositionPlace);
            //Canvas.SetTop(textBlock, x.Y);
            //Canvas.SetLeft(textBlock, x.X);
            MainWindow.AppWindow.PutOnScreen(this);

        }


        public Vector GetVector(string position)
        {
            Vector center = GetCenter();
            switch (position)
            {
                case "left":
                    //textBlock.FlowDirection = FlowDirection.RightToLeft;
                    return new Vector(center.X - StrategyWidth - (width / 2) - sizeofTexBlock.Width,
                        center.Y - (sizeofTexBlock.Height / 2));
                case "right":
                    return new Vector(center.X + StrategyWidth + (width / 2) + (sizeofTexBlock.Width / 2),
                        center.Y - (sizeofTexBlock.Height / 2));
                case "top":
                    return new Vector(center.X - (sizeofTexBlock.Width / 2), center.Y - StrategyHeight - (height));
                case "bottom":
                    return new Vector(center.X - (sizeofTexBlock.Width / 2), center.Y + StrategyHeight + (height / 2));
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
                new Typeface(this.textBlock.FontFamily, this.textBlock.FontStyle, this.textBlock.FontWeight,
                    this.textBlock.FontStretch),
                this.textBlock.FontSize,
                Brushes.Black,
                new NumberSubstitution(),
                1);

            return new Size(formattedText.Width, formattedText.Height);
        }

        public override Vector GetCenter()
        {
            return base.GetCenter();
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitOrnament(this);
        }

        public GodShape GetComponent()
        {
            return base.GetComponent();
        }

        public override double StrategyHeight
        {
            get { return base.StrategyHeight; }
            set { }
        }

        public override double StrategyWidth
        {
            get { return base.StrategyWidth; }
            set { }
        }
    }
}