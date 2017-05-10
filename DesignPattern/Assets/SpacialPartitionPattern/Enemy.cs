using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SpatialPartition
{
    public class Enemy : Soldier
    {

        private Grid grid;
        private float mapWidth;
        private GameObject newEnemy;

        public Enemy(GameObject newEnemy, float mapWidth, Grid grid)
        {
            this.newEnemy = newEnemy;
            this.mapWidth = mapWidth;
            this.grid = grid;
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
