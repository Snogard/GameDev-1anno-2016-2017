using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroid
{
    /// <summary>
    /// class that manage the game and spawn asteroids
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region Inspector
        /// <summary>
        /// the prefab of the player
        /// </summary>
        [SerializeField]
        private GameObject _playerPrefab;

        [Header("Asteroids Info")]
        /// <summary>
        /// the prefab of the asteroid
        /// </summary>
        [SerializeField]
        private GameObject _asteroidPrefab;
        /// <summary>
        /// maximum number of asteroids
        /// </summary>
        [SerializeField]
        private int _maxAsteroids;

        /// <summary>
        /// maximum asteroid spawn distance from the player
        /// </summary>
        [SerializeField]
        private float _maxSpawnDistance;
        /// <summary>
        /// minimum asteroid spawn distanc from yje player
        [SerializeField]
        private float _minSpawnSistance;
        /// <summary>
        /// asteroid spawn delay
        /// </summary>
        [SerializeField]
        private float _spawnDelay;
        #endregion

        /// <summary>
        /// the tranform of the player
        /// </summary>
        private Transform _playerTranform;

        /// <summary>
        /// current asteroid count
        /// </summary>
        private int asteroidCount;

        /// <summary>
        /// singleton attribute
        /// </summary>
        public static GameManager instance;

        void Awake()
        {
            if (instance == null)
            {

                instance = this;
            }
            else if (instance != this)
            {

                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }
        // Use this for initialization
        void Start()
        {
            asteroidCount = 0;

            _playerTranform = Instantiate(_playerPrefab).transform;
            StartCoroutine(SpawnAsteroid());
        }

        /// <summary>
        /// spawns asteroid with a time dalay if the total number does not exeed the maxium
        /// </summary>
        /// <returns></returns>
        IEnumerator SpawnAsteroid()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnDelay);
                if (asteroidCount < _maxAsteroids)
                {
                    Vector3 position = new Vector3(Random.Range(-_maxSpawnDistance, _maxSpawnDistance), Random.Range(-_maxSpawnDistance, _maxSpawnDistance) , Random.Range(-_maxSpawnDistance, _maxSpawnDistance)) + _playerTranform.position;
                    Instantiate(_asteroidPrefab, position, Quaternion.identity);
                    asteroidCount++;
                }

            }
        }
        /// <summary>
        /// descrase the number of asteroid count
        /// </summary>
        public void DestroyedAsteroid()
        {
            asteroidCount--;
        }
    }
}