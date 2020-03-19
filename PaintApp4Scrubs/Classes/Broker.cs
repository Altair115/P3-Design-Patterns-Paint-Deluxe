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
        private Stack<ICommand> commands = new Stack<ICommand>();
        private Stack<ICommand> undoCommands = new Stack<ICommand>();
        public void DoCommand(ICommand command)
        {
            commands.Push(command);
            command.Execute();
            if (undoCommands.Count != 0)
            {
                undoCommands.Clear();
            }
            
        }
        public void UndoCommand()
        {
            if (commands.Count == 0)
            {
                return;
            }
            var poptcommand = commands.Pop();
            poptcommand.UnExecute();
            undoCommands.Push(poptcommand);
        }
    }
}
