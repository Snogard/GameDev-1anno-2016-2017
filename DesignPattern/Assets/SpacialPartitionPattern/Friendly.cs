using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SpatialPartition
{
    public class Friendly : Soldier
    {
        private float mapWidth;
        private GameObject newFriendly;

        public Friendly(GameObject newFriendly, float mapWidth)
        {
            this.newFriendly = newFriendly;
            this.mapWidth = mapWidth;
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
