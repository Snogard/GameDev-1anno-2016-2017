using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroid
{
    /// <summary>
    /// class to hadle a projectile
    /// </summary>
    public class Projectile : MonoBehaviour
    {

        /// <summary>
        /// the speed of the fired projectile
        /// </summary>
        [SerializeField]
        private float _speed;
        /// <summary>
        /// the lifetime of the projectile in seconds
        /// </summary>
        [SerializeField]
        private float _lifeTime;



        void Awake()
        {

        }

        void Start()
        {
            Destroy(gameObject, _lifeTime);
        }

        void FixedUpdate()
        {
            transform.Translate(transform.forward * _speed * Time.fixedDeltaTime);
        }


    }
}
