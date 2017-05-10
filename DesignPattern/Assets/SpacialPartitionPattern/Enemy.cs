using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SpatialPartition
{
    public class Enemy : Soldier
    {
        private Grid grid;

        public Enemy(GameObject newEnemy, float mapWidth, Grid grid)
        {
            this.soldierObj = newEnemy;
            this.mapWidth = mapWidth;
            this.grid = grid;
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
