using System;
using System.Collections.Generic;
using System.Text;
using PaintApp4Scrubs.Classes.VisitorCommands;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Commands
{
    /// <summary>
    /// print the total hierarchy to a file
    /// </summary>
    class SaveFile : ICommand
    {
        private readonly Boxer _boxer;
        /// <summary>
        /// Constructor of SaveFile
        /// </summary>
        /// <param name="box">the box where all objects are located in </param>
        public SaveFile(Boxer box)
        {
            _boxer = box;
        }
        /// <summary>
        /// executes the Display visitor
        /// </summary>
        public void Execute()
        {
            _boxer.Accept(new VisitorDisplay(true));
        }

        /// <summary>
        /// you cant undo a save file 
        /// </summary>
        public void UnExecute()
        {
            
        }
    }
}
