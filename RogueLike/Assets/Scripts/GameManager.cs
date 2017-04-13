using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoardManager))]
public class GameManager : MonoBehaviour {

    BoardManager _boardManger;
    [SerializeField]
    int _level = 1;

    void Awake()
    {
        _boardManger = GetComponent<BoardManager>();
    }
	// Use this for initialization
	void Start () {
        InitGame();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void InitGame()
    {
        _boardManger.GenerateMap(_level);
    }
}
