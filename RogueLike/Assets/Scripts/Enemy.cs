using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovingObject
{

    private Animator _animator;
    private Transform _target;
    public float moveTime=0.5f;
    public int playerDamage;
    [SerializeField]
    [ReadOnly]
    private bool _skipMove;

    // Use this for initialization
    protected override void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        GameManager.instance.addEnemy(this);
    }

    // Update is called once per frame
    void Update()
    {

    }


   


    protected override void OnCantMove<T>(T component)
    {
        Player hitPlayer = component as Player;
        if(hitPlayer!=null)
        {
            hitPlayer.LoseFood(this.playerDamage);
            _animator.SetTrigger("EnemyAttack");
        }
    }

    protected override void OnMove()
    {
        throw new NotImplementedException();
    }
    protected override void AttemptMove<T>(int xDir, int yDir)
    {
        if (!_skipMove)
        {
            _skipMove = false;
            return;
        }
        base.AttemptMove<T>(xDir, yDir);

        _skipMove = true;

    }

    public void MoveEnemy()
    {
        int xDir = 0;
        int yDir = 0;
        if (Mathf.Abs(_target.position.x - transform.position.x) < float.Epsilon)
        {
            yDir = (_target.position.y < transform.position.y) ? -1 : 1;

        }
        else
        {
            xDir = (_target.position.x < transform.position.x) ? -1 : 1;
        }
        AttemptMove<Player>(xDir, yDir);
    }
}
