using System;
using System.Collections.Generic;
using System.Text;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes
{
    class Broker
    {
        List<ICommand> commands = new List<ICommand>();
    }
}
