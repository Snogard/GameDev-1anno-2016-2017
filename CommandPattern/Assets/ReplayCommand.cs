using System;
using UnityEngine;

namespace CommandPattern
{
    internal class ReplayCommand : Command
    {
        public override void Execute(Transform tranfsorm, ICommand command)
        {
            InputHandler.shouldStartReplay = true;
        }

     
    }
}