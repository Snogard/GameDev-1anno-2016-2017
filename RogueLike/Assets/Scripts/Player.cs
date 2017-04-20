using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MovingObject
{
    #region Inspector
    public int wallDamage = 1;
    public int pointsPerFood = 10;
    public int pointsPerSoda = 20;
    public float newLevelDelay = 1f;

    [SerializeField]
    [ReadOnly]
    private int _food;
    #endregion

    private Animator _animator;
    [SerializeField]                                              
    private Text _foodText;
    #region Mono
    // Use this for initialization
    protected override void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
        _food = GameManager.instance._playerFoodPoints;
        this._foodText.text = "Food: " + _food;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.playerTurn)
        {
            return;
        }
        Debug.Log("e il mio turno");
        int horizontal = 0;
        int vertical = 0;
        horizontal = (int)Input.GetAxisRaw("Horizontal");
        vertical = (int)Input.GetAxisRaw("Vertical");
        if (horizontal != 0)
        {
            vertical = 0;

        }
        if (vertical != 0 || horizontal != 0)
        {
            AttemptMove<Wall>(horizontal, vertical);
        }
        Debug.Log(vertical + "+" + horizontal);
    }

    void OnDisable()
    {
        GameManager.instance._playerFoodPoints = _food;
    }
    #endregion

    private bool isGameOver()
    {
        return _food <= 0;
    }
    protected override void AttemptMove<T>(int xDir, int yDir)
    {
        base.AttemptMove<T>(xDir, yDir);
        _food--;
        if (isGameOver())
        {
            GameManager.instance.GameOver();
        }
        GameManager.instance.playerTurn = false;
    }

    protected override void OnCantMove<T>(T component)
    {
        Wall hitWall = component as Wall;
        if (hitWall != null)
        {
            hitWall.DamageWall(wallDamage);
            _animator.SetTrigger("PlayerChop");
        }
    }

    protected override void OnMove()
    {
        //TODO add audio effect
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Exit"))
        {
            Invoke("Restart", this.newLevelDelay);
            enabled = false;
        }
        else if (other.CompareTag("Food"))
        {
            _food += this.pointsPerFood;
            other.gameObject.SetActive(false);
            this._foodText.text = "Food: " + _food;

        }
        else if (other.CompareTag("Soda"))
        {
            _food += this.pointsPerSoda;
            other.gameObject.SetActive(false);
            this._foodText.text = "Food: " + _food;

        }
    }

    public void LoseFood(int loss)
    {
        _animator.SetTrigger("PlayerHit");
        _food -= loss;
        if (isGameOver())
        {
            GameManager.instance.GameOver();
        }
        this._foodText.text = "Food: " + _food;
    }
}
