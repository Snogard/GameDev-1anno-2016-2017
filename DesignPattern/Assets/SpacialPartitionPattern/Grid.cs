using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SpatialPartition
{
    public class Grid : MonoBehaviour
    {
        private int cellSize;
        private int mapWidth;

        public Grid(int mapWidth, int cellSize)
        {
            this.mapWidth = mapWidth;
            this.cellSize = cellSize;
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
