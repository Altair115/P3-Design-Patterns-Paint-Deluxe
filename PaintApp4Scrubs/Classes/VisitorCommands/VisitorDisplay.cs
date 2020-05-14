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

        public VisitorDisplay(bool isHead)
        {
            _isHead = isHead;
            _printer.ClearFile();
        }

        public void Visit(GodShape godShape)
        {
            _printer.PrintToFile($"{godShape.Depth}{godShape.ToString()}");
        }
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

        public void VisitLine(BaseShape line)
        {
            _printer.PrintToFile($"{line.Depth}{line.ToString()}");
        }

        public void VisitSquare(BaseShape square)
        {
            _printer.PrintToFile($"{square.Depth}{square.ToString()}");
        }

        public void VisitTriangle(BaseShape triangle)
        {
            _printer.PrintToFile($"{triangle.Depth}{triangle.ToString()}");
        }
        public void VisitEllipse(BaseShape ellipseBaseShape)
        {
            _printer.PrintToFile($"{ellipseBaseShape.Depth}{ellipseBaseShape.ToString()}");
        }
    }
}
