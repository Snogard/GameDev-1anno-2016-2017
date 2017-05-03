using System;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    internal class UndoCommand : Command
    {
        public override void Execute(Transform tranfsorm, ICommand command)
        {
            List<ICommand> oldCommands = InputHandler.oldCommands;
            if(oldCommands.Count>0)
            {
                ICommand lastestCommand = oldCommands[oldCommands.Count - 1];
                lastestCommand.Undo(tranfsorm);
                oldCommands.RemoveAt(oldCommands.Count - 1);

            }
        }

    }
}