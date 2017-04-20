using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
    [RequireComponent(typeof(BoardManager))]
    public class GameManager : MonoBehaviour
    {

        public static GameManager instance = null;

        public int _playerFoodPoints = 100;
        [ReadOnly]
        public bool playerTurn = true;
        public float turnDelay = 0.1f;
        public float levelStartDelay = 2f;

        private bool _enemiesMoving;
        private List<Enemy> _enemies;
        BoardManager _boardManger;
        [SerializeField]
        int _startLevel = 2;
        [SerializeField]
        [ReadOnly]
        int _currentLevel;


        private Text _levelText;
        private GameObject _levelImage;
        private bool _doingSetUp;
        private bool isfirstRun = true;

        void Awake()
        {
            //Singleton
            if (instance == null)
            {
                instance = this;

            }
            else
            {
                if (instance != this)
                {
                    Destroy(gameObject);
                }
            }
            DontDestroyOnLoad(gameObject);

            _boardManger = GetComponent<BoardManager>();
            _enemies = new List<Enemy>();
            _currentLevel = _startLevel;

        }

        void InitGame()
        {
            _enemies.Clear();
            _doingSetUp = true;
            _levelImage = GameObject.Find("imgLevel");
            _levelText = GameObject.Find("lblLevel").GetComponent<Text>();
            _levelText.text = "Day " + _currentLevel;
            _levelImage.SetActive(true);
            _boardManger.GenerateMap(_currentLevel);

        }
        private void HideLevelImage()
        {
            _levelImage.SetActive(true);
            _doingSetUp = false;
        }
        public void GameOver()
        {
            _levelText.text = "After " + _currentLevel + "days, you starved";
            this.enabled = false;
        }
        IEnumerator MoveEnemies()
        {
            _enemiesMoving = true;
            yield return new WaitForSeconds(this.turnDelay);
            if (_enemies.Count == 0)
            {
                yield return new WaitForSeconds(this.turnDelay);
            }
            for (int i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].MoveEnemy();
                yield return new WaitForSeconds(_enemies[i].moveTime);

            }
            _enemiesMoving = false;
            this.playerTurn = true;
        }
        private void Update()
        {
            if (this.playerTurn || _enemiesMoving)
            {
                return;
            }
            StartCoroutine(MoveEnemies());

        }
        public void addEnemy(Enemy enemy)
        {
            _enemies.Add(enemy);
        }
        private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
        {
            if (isfirstRun)
            {
                _currentLevel++;
                InitGame();
                HideLevelImage();
            }
            else
            {
                _currentLevel++;
                InitGame();
                HideLevelImage();
            }


        }
        void OnEnable()
        {
            SceneManager.sceneLoaded += OnLevelFinishedLoading;
        }
        void OnDisable()
        {
            SceneManager.sceneLoaded -= OnLevelFinishedLoading;
        }
    }

