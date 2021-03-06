﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(AICharacterControl))]
public class StateController : MonoBehaviour
{

    public enum ETargetType
    {
        WAYPOINT,
        PLAYER
    }

    [SerializeField]
    private string _playerTag = "Player";

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private GameObject[] _wayPoints;

    private IState _currentState;
    private AICharacterControl _characterControl;
    [SerializeField]
    private int _currentWaypoint;

    private void Awake()
    {
        _currentState = new PatroState();
        
        _characterControl = GetComponent<AICharacterControl>();
        _currentWaypoint = 0;
        _characterControl.SetTarget(_wayPoints[0].transform);
    }

    private void Update()
    {
        _currentState.UpdateState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_playerTag))
        {
            _currentState.OnTriggerEnter(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(_playerTag))
        {
            _currentState.OnTriggerExit(this);
        }
    }
    public void ChangeState(IState newState)
    {
        _currentState = newState;
    }
    public void SetTarget(ETargetType target)
    {
        if (_characterControl != null)
        {
            switch (target)
            {
                case ETargetType.PLAYER:
                    _characterControl.SetTarget(_player.transform);
                    break;
                case ETargetType.WAYPOINT:
                    _currentWaypoint=(_currentWaypoint+1)%_wayPoints.Length;
                    _characterControl.SetTarget(_wayPoints[_currentWaypoint].transform);
                    break;
            }

        }
    }
    public Transform GetCurrentWayPoint()
    {
        return _wayPoints[_currentWaypoint].transform;
    }
   
}
