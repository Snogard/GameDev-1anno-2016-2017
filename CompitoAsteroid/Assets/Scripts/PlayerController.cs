using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroid
{
    /// <summary>
    /// class that manage the player behaviour
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        #region Inpsector
        [Header("Speed")]
        /// <summary>
        /// the base speed of the player
        /// </summary>
        [SerializeField]
        private float _baseSpeed;
        /// <summary>
        /// the incrased speed of the player
        /// </summary>
        [SerializeField]
        private float _maxSpeed;
        /// <summary>
        /// the decrasedSpeed of the player
        /// </summary>
        [SerializeField]
        private float _minSpeed;
        /// <summary>
        /// the acceleration of the player to reach max speed
        /// </summary>
        [SerializeField]
        private float _acceleration;
        /// <summary>
        /// the rotation speed of the player
        /// </summary>
        [SerializeField]
        private float _rotationSpeed;

        [Header("Weapon")]
        /// <summary>
        /// how much delay the player has before shooting another projectile
        /// </summary>
        [SerializeField]
        private float _rateOfFire;
        /// <summary>
        /// the speed of the fired projectile
        /// </summary>
        [SerializeField]
        private float projectileSpeed;
        #endregion

        #region ButtonAttributes
        private const string _incraseSpeedButton = "Forward";
        private const string _decraseSpeedButton = "Backward";

        private const string _rightLeftAxis = "Horizontal";
        private const string _upDownAxis = "Vertical";

        private float _rightLeftAxisResult;
        private float _upDownAxisResult;
        #endregion

        /// <summary>
        /// the current speed of the player
        /// </summary>
        [SerializeField]
        private float _currentSpeed;


        


        // Use this for initialization
        void Start()
        {
            _currentSpeed = _baseSpeed;
        }

        // Update is called once per frame
        void Update()
        {
            CheckForInput();
        }

        /// <summary>
        /// check for user input
        /// </summary>
        private void CheckForInput()
        {
            //TODO sostituire con lp' accelerazione

            if (Input.GetButton(_incraseSpeedButton))
            {
                //increase speed
                if (_currentSpeed < _maxSpeed)
                {
                    _currentSpeed += _acceleration * Time.deltaTime;
                    if (_currentSpeed > _maxSpeed)
                    {
                        _currentSpeed = _maxSpeed;
                    }
                }
            }
            else if (Input.GetButton(_decraseSpeedButton))
            {
                //decrase speed
                if (_currentSpeed > _minSpeed)
                {
                    _currentSpeed -= _acceleration * Time.deltaTime;
                    if (_currentSpeed < _minSpeed)
                    {
                        _currentSpeed = _minSpeed;
                    }
                }
            }
            else
            {
                if(_currentSpeed>_baseSpeed)
                {
                    _currentSpeed -= _acceleration * Time.deltaTime;
                    if(_currentSpeed<_baseSpeed)
                    {
                        _currentSpeed = _baseSpeed;
                    }

                    
                }
                if (_currentSpeed <_baseSpeed)
                {
                    _currentSpeed += _acceleration * Time.deltaTime;
                    if(_currentSpeed>_baseSpeed)
                    {
                        _currentSpeed = _baseSpeed;
                    }
                }

            }
                
            /*

            // if the user leave the buttons the current speed become basespeed
            if (Input.GetButtonUp(_incraseSpeedButton))
            {
                _currentSpeed = _baseSpeed;
            }
            else if (Input.GetButtonUp(_decraseSpeedButton))
            {
                _currentSpeed = _baseSpeed;
            }*/

            _rightLeftAxisResult = Input.GetAxisRaw(_rightLeftAxis);
            _upDownAxisResult = Input.GetAxisRaw(_upDownAxis);



        }

        void FixedUpdate()
        {
            transform.Translate(transform.forward * _currentSpeed * Time.fixedDeltaTime);
            transform.Rotate(new Vector3(_upDownAxisResult * -1, _rightLeftAxisResult, 0) * _rotationSpeed * Time.fixedDeltaTime);
        }



    }
}