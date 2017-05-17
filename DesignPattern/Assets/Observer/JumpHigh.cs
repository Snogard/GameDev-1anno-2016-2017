using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ObserverPattern
{
    public class JumpHigh : BoxEvent
    {
        public override float GetJumpForce()
        {
            return 90;
        }
    }
}