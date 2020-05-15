using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PaintApp4Scrubs.Classes
{
    public class Ornament : Decorator
    {
        public string Name;
        public Vector OrnamentPos;

        protected override Geometry DefiningGeometry { get; }

        public override void Decorate()
        {
            base.Decorate();
            //do stuff
            TextBlock textBlock = new TextBlock();
            textBlock.Text = Name.ToString();
            Canvas.SetTop(textBlock, 100);
            Canvas.SetLeft(textBlock, 100);
            MainWindow.AppWindow.PutOnScreen(textBlock);
        }
    }
}