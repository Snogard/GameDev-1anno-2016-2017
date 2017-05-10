using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SpatialPartition
{
    public abstract class Soldier
    {
        public MeshRenderer soldierMeshRederer;
        protected float mapWidth;
        protected GameObject soldierObj;



        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public abstract void Move();

        public abstract void Move(Soldier closestEnemy);
        
    }
}
