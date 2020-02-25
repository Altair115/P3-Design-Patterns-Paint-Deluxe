using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Controls;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes
{
    public class Draw : ICommand
    {
        private Shape shape;
        public Draw(Shape _shape)
        {
            shape = _shape;
        }
        public void Execute()
        {

           // Canvas.Children.Add(shape);
        }
    }
}
