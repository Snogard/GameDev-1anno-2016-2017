using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random; //disambiguazione

public class BoardManager : MonoBehaviour
{
    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int minimum, int maximum)
        {
            this.minimum = minimum;
            this.maximum = maximum;
        }
    }

    [Header("Dimensions")]
    [SerializeField]
    int columns = 8;

    [SerializeField]
    int rows = 8;

    [Header("Walls & Food")]
    [SerializeField]
    Count wallCount = new Count(5, 9);

    [SerializeField]
    Count foodCount = new Count(1, 5);

    #region Tiles
    [Header("Tiles")]
    [SerializeField]
    GameObject exit;
    [SerializeField]
    GameObject[] floorTiles;
    [SerializeField]
    GameObject[] wallTiles;
    [SerializeField]
    GameObject[] enemysTiles;
    [SerializeField]
    GameObject[] outerWallTiles;
    [SerializeField]
    GameObject[] foodTiles;
    #endregion


    Transform _boardHolder;
    /// <summary>
    /// spawn oggetti onon floor
    /// </summary>
    List<Vector3> _gridPositions = new List<Vector3>();

    #region MonoImplementation
    // Use this for initialization
    // Update is called once per frame
    void Update()
    {

    }
    #endregion


    void InitializeGridPosition()
    {
        _gridPositions.Clear();

        for (int x = 1; x < columns - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                _gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }
    void BoardSetup()
    {
        _boardHolder = new GameObject("Board").transform;
        _boardHolder.position = transform.position;
        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate;

                if (x == -1 || x == columns || y == -1 || y == rows)
                {
                    toInstantiate = outerWallTiles[Random.Range(0, outerWallTiles.Length)];
                }
                else
                {
                    toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                }

                Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity, _boardHolder);

            }
        }
    }
    Vector3 RandomPosition()
    {
        int index = Random.Range(0, _gridPositions.Count);
        Vector3 position = _gridPositions[index];
        _gridPositions.RemoveAt(index);
        return position;
    }

    private void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum);
        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tileChoice, randomPosition, Quaternion.identity,_boardHolder);
        }
    }
    public void GenerateMap(int level)
    {
        BoardSetup();
        InitializeGridPosition();
        LayoutObjectAtRandom(wallTiles, wallCount.minimum, wallCount.maximum);
        LayoutObjectAtRandom(foodTiles, foodCount.minimum, foodCount.maximum);

        int enemyCount = (int)Mathf.Log(level, 2f);
        LayoutObjectAtRandom(enemysTiles, enemyCount, enemyCount);

        Instantiate(exit, new Vector3(columns - 1, rows - 1, 0f), Quaternion.identity,_boardHolder);
    }
}
