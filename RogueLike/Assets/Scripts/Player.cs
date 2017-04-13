using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingObject
{

    public int wallDamage = 1;
    public int pointsPerFood = 10;
    public int pointsPerSoda = 20;
    public float newLevelDelay = 1f;


    private Animation _animator;
    [SerializeField]
    [ReadOnly]
    private int _food;



    // Use this for initialization
    protected override void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void OnCantMove<T>(T component)
    {
        throw new NotImplementedException();
    }

    protected override void OnMove()
    {
        throw new NotImplementedException();
    }

}
