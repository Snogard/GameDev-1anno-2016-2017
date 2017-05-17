using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ObserverPattern
{
    public class JumpLittle : BoxEvent
    {
        public override float GetJumpForce()
        {
            return 30;
        }
    }
}