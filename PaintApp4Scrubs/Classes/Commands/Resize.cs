﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Classes.Commands;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Commands
{

    class Resize : ICommand
    {
        private GodShape shape;
        private Vector distance;
        public Resize(GodShape _shape, Vector _distance)
        {
            shape = _shape;
            distance = _distance;
        }

        public void Execute()
        {
            shape.Resize(distance);
        }

        public void UnExecute()
        {
            shape.Resize(distance * -1);
        }
    }
}
