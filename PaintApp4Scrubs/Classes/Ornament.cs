using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PaintApp4Scrubs.Classes.Shapes;

namespace PaintApp4Scrubs.Classes
{
    public class Ornament : Decorator
    {
        public string Name = "";
        public string PositionPlace = "";
        public Vector OrnamentPos;

        protected override Geometry DefiningGeometry { get; }

        public Ornament(GodShape godShape) : base(godShape) { }

        public override void Decorate()
        {
            base.Decorate();
            //do stuff
            TextBlock textBlock = new TextBlock();
            textBlock.Text = Name.ToString();
            Vector x = GetVector(PositionPlace);
            Canvas.SetTop(textBlock, x.Y);
            Canvas.SetLeft(textBlock, x.X);
            MainWindow.AppWindow.PutOnScreen(textBlock);
        }
        

        public Vector GetVector(string position)
        {
            Vector center = GetCenter();
            switch (position)
            {
                case "left":
                    return new Vector(center.X + 50,center.Y);
                case "right":
                    return new Vector(center.X - 50, center.Y);
                case "top":
                    return new Vector(center.X , center.Y + 50);
                case "bottom":
                    return new Vector(center.X, center.Y - 50);
                default:
                    return new Vector(0,0);
            }
        }

        public override Vector GetCenter()
        {
            return base.GetCenter();
        }
    }
}