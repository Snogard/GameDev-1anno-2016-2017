using System;
using UnityEngine;

namespace CommandPattern
{
    internal class MoveReverse : Command
    {

        public override void Execute(Transform tranfsorm, ICommand command)
        {
            Move(tranfsorm);
            InputHandler.oldCommands.Add(command);
        }


        public override void Undo(Transform tranf)
        {
            tranf.Translate(tranf.forward * moveDistance);
        }
        public override void Move(Transform tranf)
        {
            tranf.Translate(-tranf.forward * moveDistance);
        }
    }
}