using System;
using System.Collections.Generic;
using System.Text;

namespace PaintApp4Scrubs.Interfaces
{
    /// <summary>
    /// the command interface
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Execute Command
        /// </summary>
        public void Execute();
        /// <summary>
        /// Undo the command or do the opposite
        /// </summary>
        public void UnExecute();
    }
}
