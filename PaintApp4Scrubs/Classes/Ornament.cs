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
        private TextBlock textBlock = new TextBlock();
        protected override Geometry DefiningGeometry { get; }

        public Ornament(GodShape godShape) : base(godShape) { }

        public override void Decorate()
        {
            //base.Decorate();
            ////do stuff
            //textBlock.Text = Name.ToString();
            //sizeofTexBlock = MeasureString(Name);
            //Vector x = GetVector(PositionPlace);
            //Canvas.SetTop(textBlock, x.Y);
            //Canvas.SetLeft(textBlock, x.X);
            MainWindow.AppWindow.PutOnScreen(textBlock);

        }
        

        public Vector GetVector(string position)
        {
            Vector center = GetCenter();
            switch (position)
            {
                case "left":
                    //textBlock.FlowDirection = FlowDirection.RightToLeft;
                    return new Vector(center.X - offset - (width/2) - sizeofTexBlock.Width, center.Y - (sizeofTexBlock.Height / 2));
                case "right":
                    return new Vector(center.X + offset + (width/2) + (sizeofTexBlock.Width / 2), center.Y - (sizeofTexBlock.Height / 2));
                case "top":
                    return new Vector(center.X - (sizeofTexBlock.Width / 2), center.Y - offset - (height));
                case "bottom":
                    return new Vector(center.X - (sizeofTexBlock.Width / 2), center.Y + offset + (height/2));
                default:
                    return new Vector(0,0);
            }
        }
        private Size MeasureString(string candidate)
        {
            var formattedText = new FormattedText(
                candidate,
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface(this.textBlock.FontFamily, this.textBlock.FontStyle, this.textBlock.FontWeight, this.textBlock.FontStretch),
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
    }
}