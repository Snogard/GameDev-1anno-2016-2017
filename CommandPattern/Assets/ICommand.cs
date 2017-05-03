using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CommandPattern
{
    public interface ICommand
    {
        void Execute(Transform tranfsorm, ICommand command);
        void Move(Transform tranf);
        void Undo(Transform tranf);
    }
}