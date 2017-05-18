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
        /// how much projectile the player can shoot in one second
        /// </summary>
        [SerializeField]
        private float _rateOfFire;
        /// <summary>
        /// prefab of the projectile
        /// </summary>
        [SerializeField]
        private Projectile _projectilePrefab;
        /// <summary>
        /// the points where projectile spawns
        /// </summary>
        [SerializeField]
        private Transform[] _firePoints;
        #endregion

        #region ButtonAttributes
        private const string _incraseSpeedButton = "Forward";
        private const string _decraseSpeedButton = "Backward";

        private const string _rightLeftAxis = "Horizontal";
        private const string _upDownAxis = "Vertical";

        private float _rightLeftAxisResult;
        private float _upDownAxisResult;
        /// <summary>
        /// name of the fire button
        /// </summary>
        private const string _fireButton = "Fire1";
        #endregion

        /// <summary>
        /// the current speed of the player
        /// </summary>
        private float _currentSpeed;

        /// <summary>
        /// controlls if the olayer can shoot
        /// </summary>
        private bool _canShoot;





        // Use this for initialization
        void Start()
        {
            _currentSpeed = _baseSpeed;
            _canShoot = true;
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
                if (_currentSpeed > _baseSpeed)
                {
                    _currentSpeed -= _acceleration * Time.deltaTime;
                    if (_currentSpeed < _baseSpeed)
                    {
                        _currentSpeed = _baseSpeed;
                    }


                }
                if (_currentSpeed < _baseSpeed)
                {
                    _currentSpeed += _acceleration * Time.deltaTime;
                    if (_currentSpeed > _baseSpeed)
                    {
                        _currentSpeed = _baseSpeed;
                    }
                }

            }

            //fire projectiles
            if(Input.GetButton(_fireButton))
            {
                if (_canShoot)
                {
                    Shoot();
                    _canShoot = false;
                    StartCoroutine(ShootDelay(1/_rateOfFire));
                }
            }

            _rightLeftAxisResult = Input.GetAxisRaw(_rightLeftAxis);
            _upDownAxisResult = Input.GetAxisRaw(_upDownAxis);



        }

        /// <summary>
        /// move the player
        /// </summary>
        void FixedUpdate()
        {
            transform.Translate(transform.forward * _currentSpeed * Time.fixedDeltaTime);
            transform.Rotate(new Vector3(_upDownAxisResult * -1, _rightLeftAxisResult, 0) * _rotationSpeed * Time.fixedDeltaTime);
        }

        /// <summary>
        /// shoot the projectile in every firepoint
        /// </summary>
        private void Shoot()
        {
            for (int i = 0; i < _firePoints.Length; i++)
            {
                Projectile proj = Instantiate<Projectile>(_projectilePrefab, _firePoints[i].position, Quaternion.identity);
                proj.GetComponent<Rigidbody>().AddForce(transform.forward * proj._speed,ForceMode.Impulse);
            }
        }
        /// <summary>
        /// wait an ammount of time before the player can shoot again
        /// </summary>
        /// <param name="time">seconsd to wait</param>
        /// <returns></returns>
        private IEnumerator ShootDelay(float time)
        {
            yield return new WaitForSeconds(time);
            _canShoot = true;
        }

    }
}