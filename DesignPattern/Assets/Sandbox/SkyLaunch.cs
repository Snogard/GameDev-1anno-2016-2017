using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SanboxPattern
{
    public class SkyLaunch : Superpower
    {

        public override void Activate()
        {
            Move(10);
            PlaySound("SkyLaunch");
            SpawnParticles();
        }
    }
}
