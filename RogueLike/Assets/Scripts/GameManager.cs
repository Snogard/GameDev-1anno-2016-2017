using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoardManager))]
public class GameManager : MonoBehaviour {


    public static GameManager instance = null;

    public int _playerFoodPoints= 100;
    [SerializeField][ReadOnly] bool playerTurn = true;
    
    BoardManager _boardManger;
    [SerializeField]
    int _startLevel = 2;
    [SerializeField][ReadOnly]
    int _currentLevel;

    void Awake()
    {
        //Singleton
        if(instance==null)
        {
            instance = this;
            
        }
        else
        {
            if(instance!=this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);

        _boardManger = GetComponent<BoardManager>();
        
    }
	// Use this for initialization
	void Start () {
        _currentLevel = _startLevel;
        InitGame();
	}
	
	/*// Update is called once per frame
	void Update () {
		
	}*/
    void InitGame()
    {
        _boardManger.GenerateMap(_currentLevel);
    }

    public void GameOver()
    {
        this.enabled = false;

    }
}
