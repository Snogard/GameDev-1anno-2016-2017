using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SpatialPartition
{
    public class Friendly : Soldier
    {
        

        public Friendly(GameObject newFriendly, float mapWidth)
        {
            this.soldierTranform = newFriendly.transform;
            this.mapWidth = mapWidth;
            this.walkSpeed = 2f;
        }

        public override void Move(Soldier soldier)
        {
            //ruota verso il nemico
            soldierTranform.rotation = Quaternion.LookRotation(soldier.soldierTranform.position - soldierTranform.position);
            //si muove verso il nemico
            soldierTranform.Translate(Vector3.forward * Time.deltaTime * walkSpeed);
        }
    }
}
