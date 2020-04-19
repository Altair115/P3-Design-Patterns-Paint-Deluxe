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
       public void Execute();
       public void UnExecute();
    }
}
