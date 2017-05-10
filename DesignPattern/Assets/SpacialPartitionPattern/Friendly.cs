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
            this.soldierObj = newFriendly;
            this.mapWidth = mapWidth;
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void Move(Soldier closestEnemy)
        {
            throw new NotImplementedException();
        }
    }
}
