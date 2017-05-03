using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CommandPattern
{
    public abstract class Command : ICommand
    {

        protected float moveDistance = 1f;

        public abstract void Execute(Transform tranfsorm, ICommand command);
        public virtual void Move(Transform tranf){}
        public virtual void Undo(Transform tranf){}
        
    }
}
