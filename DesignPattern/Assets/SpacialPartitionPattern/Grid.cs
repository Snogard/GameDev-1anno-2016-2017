using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SpatialPartition
{
    public class Grid
    {
      
        private int cellSize;
        private int mapWidth;

        private Soldier[,] cells;

        public Grid(int mapWidth, int cellSize)
        {
            this.mapWidth = mapWidth;
            this.cellSize = cellSize;
            int numberOfCells = mapWidth / cellSize;
            cells = new Soldier[numberOfCells, numberOfCells];
        }


        public void Add(Soldier soldier)
        {
            // dov/ è il soldato
            int cellX= (int) (soldier.soldierTranform.position.x/cellSize);
            int cellY= (int) (soldier.soldierTranform.position.y/cellSize);
            //prende il soldato dalla posizione
            soldier.previusSoldier = null;
            soldier.nextSoldier = cells[cellX, cellY];
            //associa questa cella con questo solato
            cells[cellX, cellY] = soldier;
            if(soldier.nextSoldier!=null)
            {
                soldier.nextSoldier.previusSoldier = soldier;
            }

                
        }

        public Soldier FindClosestEnemy(Soldier soldier)
        {
            // dov/ è il soldato
            int cellX = (int)(soldier.soldierTranform.position.x / cellSize);
            int cellY = (int)(soldier.soldierTranform.position.y / cellSize);

            Soldier enemy = cells[cellX, cellY];

            Soldier closestSoldier = null;
            float bestDistSQrt = Mathf.Infinity;
            //cerca nella lista
            while(enemy!=null)
            {
                float distSqrt = (enemy.soldierTranform.position - soldier.soldierTranform.position).sqrMagnitude;

                if(distSqrt<bestDistSQrt)
                {
                    bestDistSQrt = distSqrt;
                    closestSoldier = enemy;
                }
                //prossimo nemico
                enemy = enemy.nextSoldier;
                
            }

            return closestSoldier;
        }

        public void Move(Soldier soldier, Vector3 oldPos)
        {
            //dov' era prima
            int oldCellX = (int)oldPos.x / cellSize;
            int oldCellZ = (int)oldPos.z / cellSize;
            //dov' è ora
            int cellX = (int)soldier.soldierTranform.position.x;
            int cellZ = (int)soldier.soldierTranform.position.z;

            if(oldCellX==cellX&&oldCellZ==cellZ)
            {
                return;
            }

            //staccalo dalla lista della sua vecchia cella
            if(soldier.previusSoldier!=null)
            {
                soldier.previusSoldier.nextSoldier = soldier.nextSoldier;
            }

            if(soldier.nextSoldier!=null)
            {
                soldier.nextSoldier.previusSoldier = soldier.previusSoldier;
            }
            //se è la testa rimuovilo
            if(cells[oldCellX,oldCellZ]==soldier)
            {
                cells[oldCellX, oldCellZ] = soldier.nextSoldier;
            }

            Add(soldier);

        }
    }
}
