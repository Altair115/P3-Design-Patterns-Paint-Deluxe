using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes
{
    class Broker
    {
        List<ICommand> commands = new List<ICommand>();
    }
}
