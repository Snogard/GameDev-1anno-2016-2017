using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
namespace SpatialPartition
{
    public class Enemy : Soldier
    {
        private Grid grid;
        Vector3 currentTarget;
        Vector3 oldPos;

        public Enemy(GameObject newEnemy, float mapWidth, Grid grid)
        {
            this.soldierTranform = newEnemy.transform;
            this.soldierMeshRederer = newEnemy.GetComponent<MeshRenderer>();
            this.mapWidth = mapWidth;
            this.grid = grid;
            grid.Add(this);
            oldPos = soldierTranform.position;
            this.walkSpeed = 5f;
            GetNewTarget();
        }

        private void GetNewTarget()
        {
            currentTarget= new Vector3(Random.Range(0f, mapWidth), 0.5f, Random.Range(0f, mapWidth));

            soldierTranform.rotation = Quaternion.LookRotation(currentTarget - soldierTranform.position);
        }

        public override void Move()
        {
            soldierTranform.Translate(Vector3.forward * Time.deltaTime * walkSpeed);
            grid.Move(this, oldPos);
            oldPos = soldierTranform.position;
            if((soldierTranform.position-currentTarget).magnitude<1)
            {
                GetNewTarget();
            }
        }

    }
}
