using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.VisitorCommands
{
    class VisitorDisplay : IVisitor
    {
        private bool _isHead = false;
        private readonly ThePrinter _printer = ThePrinter.GetInstance();

        /// <summary>
        /// VisitorDisplay Constructor
        /// </summary>
        /// <param name="isHead">Check if this is the Head Component</param>
        public VisitorDisplay(bool isHead)
        {
            _isHead = isHead;
            _printer.ClearFile();
        }

        /// <summary>
        /// Visitor Function for godShape
        /// </summary>
        /// <param name="godShape">Selected Shape</param>
        public void Visit(GodShape godShape)
        {
            _printer.PrintToFile($"{godShape.Depth}{godShape.ToString()}");
        }
        /// <summary>
        /// Visitor Function for boxer
        /// </summary>
        /// <param name="boxer">Selected Box</param>
        public void Visit(Boxer boxer)
        {
            if (_isHead)
            {
                _printer.PrintToFile("canvas");
                if (boxer.GetChildren().Count != 1)
                    _printer.PrintToFile($"{boxer.Depth}Group {boxer.GetChildren().Count}");
                _isHead = false;
            }
            foreach (var x in boxer.GetChildren())
            {
                switch (x)
                {
                    case Boxer b:
                        if (b.GetChildren().Count != 1)
                        {
                            _printer.PrintToFile($"{b.Depth}Group {b.GetChildren().Count}");
                        }
                        Visit(b);
                        break;
                    case GodShape g:
                        Visit(g);
                        break;
                }
            }
        }

        /// <summary>
        /// Visitor Function for line
        /// </summary>
        /// <param name="line">Selected Shape</param>
        public void VisitLine(BaseShape line)
        {
            _printer.PrintToFile($"{line.Depth}{line.ToString()}");
        }

        /// <summary>
        /// Visitor Function for square
        /// </summary>
        /// <param name="square">Selected Shape</param>
        public void VisitSquare(BaseShape square)
        {
            _printer.PrintToFile($"{square.Depth}{square.ToString()}");
        }

        /// <summary>
        /// Visitor Function for triangle
        /// </summary>
        /// <param name="triangle">Selected Shape</param>
        public void VisitTriangle(BaseShape triangle)
        {
            _printer.PrintToFile($"{triangle.Depth}{triangle.ToString()}");
        }
        /// <summary>
        /// Visitor Function for ellipse
        /// </summary>
        /// <param name="ellipse">Selected Shape</param>
        public void VisitEllipse(BaseShape ellipse)
        {
            _printer.PrintToFile($"{ellipse.Depth}{ellipse.ToString()}");
        }

        public void VisitOrnament(Ornament ornament)
        {
            throw new NotImplementedException();
        }
    }
}
