using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroid
{
    /// <summary>
    /// random rotate an object
    /// </summary>
    public class Asteroid : MonoBehaviour
    {
        #region inspector
        /// <summary>
        /// minimum rotation & speed of the object
        /// </summary>
        [SerializeField]
        private float _minimumSpeed;
        /// <summary>
        /// maximum rotation & speed of the object
        /// </summary>
        [SerializeField]
        private float _maximumSpeed;
        /// <summary>
        /// lifetime of the asteroid
        /// </summary>
        [SerializeField]
        private float _lifeTime;

        #endregion

        /// <summary>
        /// rotation of the object
        /// </summary>
        private Vector3 _rotation;
        /// <summary>
        /// rotation sped of the object
        /// </summary>
        private float _rotationSpeed;
        /// <summary>
        /// movement speed
        /// </summary>
        private float _speed;
        /// <summary>
        /// direction
        /// </summary>
        private Vector3 _direcion;
        
        void Start()
        {
            _rotation = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            _rotationSpeed = Random.Range(_minimumSpeed, _maximumSpeed);
            _speed = Random.Range(_minimumSpeed, _maximumSpeed);
            _direcion = new Vector3(Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100))/100;
            Destroy(gameObject, _lifeTime);
        }

        void FixedUpdate()
        {
            transform.Rotate(_rotation * Time.fixedDeltaTime * _rotationSpeed);
            transform.Translate(_direcion * Time.fixedDeltaTime * _speed);

        }

        void OnDestroy()
        {
            GameManager.instance.DestroyedAsteroid();
        }
    }
}
