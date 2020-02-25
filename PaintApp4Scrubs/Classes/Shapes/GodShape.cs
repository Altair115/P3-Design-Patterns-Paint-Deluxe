using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PaintApp4Scrubs.Classes.Shapes
{
    public abstract class GodShape : Shape
    {
        public void Draw()
        {
            PaintApp4Scrubs.MainWindow.AppWindow.PutOnScreen(this);
        }
    }
}
