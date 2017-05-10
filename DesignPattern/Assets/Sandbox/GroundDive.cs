using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SanboxPattern
{
    public class GroundDive : Superpower
    {

        public override void Activate()
        {
            Move(15);
            PlaySound("GroundDive");
            SpawnParticles();
        }
    }
}
