﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SpatialPartition
{
    public class GameController : MonoBehaviour
    {
        /// <summary>
        /// prefab
        /// </summary>
        public GameObject friendlyObj;
        public GameObject enemyObj;
        //materials
        public Material enemyMaterial;
        public Material closestEnemyMaterial;
        //parents
        public Transform enemyParent;
        public Transform friendlyParent;
        //soildier list
        List<Soldier> enemySoldiers = new List<Soldier>();
        List<Soldier> friendlySoldiers = new List<Soldier>();
        //soldati più vicini
        List<Soldier> closestEnemies = new List<Soldier>();

        //grid
        float mapWidth = 50f;
        int cellSize = 10;
        //numero di soldati
        
        int numberOfSoldiers = 100;

        Grid grid;
        // Use this for initialization
        void Start()
        {
            grid = new Grid((int)mapWidth, cellSize);

            for (int i = 0; i < numberOfSoldiers; i++)
            {
                //creo soldato nemico
                Vector3 randomPos = new Vector3(Random.Range(0f, mapWidth), 0.5f, Random.Range(0f, mapWidth));
                GameObject newEnemy = Instantiate(enemyObj, randomPos, Quaternion.identity, enemyParent);
                enemySoldiers.Add(new Enemy(newEnemy, mapWidth, grid));

                //creo soldato amico
                randomPos = new Vector3(Random.Range(0f, mapWidth), 0.5f, Random.Range(0f, mapWidth));
                GameObject newFriendly = Instantiate(friendlyObj, randomPos, Quaternion.identity, friendlyParent);
                friendlySoldiers.Add(new Friendly(newFriendly, mapWidth));

            }
        }

        // Update is called once per frame
        void Update()
        {
            //muovo i nemici
            for (int i = 0; i < enemySoldiers.Count; i++)
            {
                enemySoldiers[i].Move();
            }
            //assegno i maeriali
            for (int i = 0; i < closestEnemies.Count; i++)
            {
                closestEnemies[i].soldierMeshRederer.material = enemyMaterial;
            }
            
            closestEnemies.Clear();
            //per ogni amico trova il nemico più vicino
            for (int i = 0; i < friendlySoldiers.Count; i++)
            {
                Soldier closestEnemy = grid.FindClosestEnemy(friendlySoldiers[i]);
                if(closestEnemy!=null)
                {
                    closestEnemy.soldierMeshRederer.material = closestEnemyMaterial;
                    closestEnemies.Add(closestEnemy);
                    friendlySoldiers[i].Move(closestEnemy);
                }
            }
        }
    }
}
