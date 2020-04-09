using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Classes.Commands;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes
{
    class Move : ICommand
    {
        private GodShape shape;
        private Vector newPosition;

        public Move(GodShape _shape,Vector _newPosition)
        {
            shape = _shape;
            newPosition = _newPosition;
        }

        public void Execute()
        {
            shape.Move(newPosition);
        }

        public void UnExecute()
        {
            shape.Move(newPosition);
        }
    }
}

