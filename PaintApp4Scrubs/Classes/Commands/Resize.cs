﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Classes.Commands;
using PaintApp4Scrubs.Classes.VisitorCommands;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Commands
{
    /// <summary>
    /// This class creates a command to resize the component on the canvas
    /// </summary>
    class Resize : ICommand
    {
        private readonly GodShape _component;
        private readonly Vector _distance;
        /// <summary>
        /// the constructor of the Resize class
        /// </summary>
        /// <param name="component">the component that has to be resized</param>
        /// <param name="distance">the distance of the old component and the new component</param>
        public Resize(GodShape component, Vector distance)
        {
            _component = component;
            _distance = distance;
        }
        /// <summary>
        /// executes the resize Visitor
        /// </summary>
        public void Execute()
        {
            _component.Accept(new VisitorResize(_distance));
        }
        /// <summary>
        /// executes the undo variant of the resize Visitor 
        /// </summary>
        public void UnExecute()
        {
            _component.Accept(new VisitorResize(_distance * -1));
        }
    }
}
