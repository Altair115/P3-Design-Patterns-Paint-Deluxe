using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes
{
    /// <summary>
    /// this class handles all the commands 
    /// </summary>
class Broker
{
        //the stack where all the commands are stored
        private readonly Stack<ICommand> _commands = new Stack<ICommand>();
        //the stack where all the undo commands are stored 
        private readonly Stack<ICommand> _undoCommands = new Stack<ICommand>();
        
        /// <summary>
        /// this function executes the command
        /// </summary>
        /// <param name="command">the command to be executed</param>
        public void DoCommand(ICommand command)
        {
            _commands.Push(command);
            command.Execute();
            if (_undoCommands.Count != 0)
            {
                _undoCommands.Clear();
            }
            
        }
        /// <summary>
        /// this function executes the undo version of the command 
        /// </summary>
        public void UndoCommand()
        {
            if (_commands.Count == 0) { return; }
                
            var pop = _commands.Pop();
            pop.UnExecute();
            _undoCommands.Push(pop);
        }
        /// <summary>
        /// redo the command on top of the undo stack
        /// </summary>
        public void RedoCommand()
        {
            if (_undoCommands.Count == 0)
            {
                return;
            }

            var pop = _undoCommands.Pop();
            pop.Execute();
            _commands.Push(pop);
        }
    }
}
