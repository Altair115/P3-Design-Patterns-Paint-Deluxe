using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Controls;
using PaintApp4Scrubs.Interfaces;
using PaintApp4Scrubs.Classes.Shapes;

namespace PaintApp4Scrubs.Classes
{
    public class Draw : ICommand
    {
        private GodShape shape;
        public Draw(GodShape _shape)
        {
            shape = _shape;
        }
        public void Execute()
        {
            //shape.Draw();
           // Canvas.Children.Add(shape);
        }
    }
}
