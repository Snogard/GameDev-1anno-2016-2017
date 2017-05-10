using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SpatialPartition
{
    public abstract class Soldier
    {
        
        protected float mapWidth;


        public MeshRenderer soldierMeshRederer;
        public Transform soldierTranform;

        public Soldier previusSoldier;
        public Soldier nextSoldier;

        protected float walkSpeed;


        public virtual void Move() { }

        public virtual void Move(Soldier soldier) { }
        
    }
}
