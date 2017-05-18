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
        public float _speed;
        /// <summary>
        /// the lifetime of the projectile in seconds
        /// </summary>
        [SerializeField]
        private float _lifeTime;

        /// <summary>
        /// sets the gameobject to be destroyed in _lifeTime seconds
        /// </summary>
        void Start()
        {
            Destroy(gameObject, _lifeTime);
        }

        /// <summary>
        /// move the gameobject
        /// </summary>
        void FixedUpdate()
        {
          //  transform.Translate(transform.forward * _speed * Time.fixedDeltaTime*-1);
        }
        void OnTriggerEnter(Collider other)
        {
            Destroy(other.gameObject);
        }

    }
}
