using System;
using UnityEngine;

namespace CommandPattern
{
    internal class DoNothing : Command
    {
        public override void Execute(Transform tranfsorm, ICommand command)
        {
            
        }
    }
}