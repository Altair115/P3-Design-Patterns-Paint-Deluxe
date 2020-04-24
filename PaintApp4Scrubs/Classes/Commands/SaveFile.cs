using System;
using System.Collections.Generic;
using System.Text;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Commands
{
    class SaveFile : ICommand
    {
        private readonly Boxer _boxer;
        public SaveFile(Boxer box)
        {
            _boxer = box;
        }
        public void Execute()
        {
            //_boxer.ClearFile();
            //_boxer.SaveFile();
        }

        public void UnExecute()
        {
            
        }
    }
}
