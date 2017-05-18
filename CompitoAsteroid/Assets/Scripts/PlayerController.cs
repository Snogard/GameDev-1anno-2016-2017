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
        /// <summary>
        /// the base speed of the player
        /// </summary>
        [SerializeField]
        private float baseSpeed;

        [SerializeField]
        private float incrasedSpeed;

        [SerializeField]
        private float decrasedSpeed;

        [SerializeField]
        private float currentSpeed;

        /// <summary>
        /// how much delay the player has before shooting another projectile
        /// </summary>
        [SerializeField]
        private float rateOfFire;
        /// <summary>
        /// the speed of the fired projectile
        /// </summary>
        [SerializeField]
        private float projectileSpeed;



        private const string forwardButton = "Forward";
        private const string backwardButton = "Backward";

        private const string rightLeftAxis = "Horizontal";

        // Use this for initialization
        void Start()
        {
            currentSpeed = baseSpeed;
        }

        // Update is called once per frame
        void Update()
        {
            CheckForInput();

        }

        private void CheckForInput()
        {

            if (Input.GetButtonDown(forwardButton))
            {
                //increase speed
                currentSpeed = incrasedSpeed;
            }
            else if (Input.GetButtonDown(backwardButton))
            {
                //decrase speed
                currentSpeed = decrasedSpeed;
            }


            // if the user leave the buttons the current speed become basespeed
            if (Input.GetButtonUp(forwardButton))
            {
                currentSpeed = baseSpeed;
            }
            else if (Input.GetButtonUp(backwardButton))
            {
                currentSpeed = baseSpeed;
            }
        }

        void FixedUpdate()
        {

            


            transform.Translate(transform.forward * currentSpeed * Time.fixedDeltaTime);

            /*

            if(Input.GetAxisRaw(rightLeftAxis) >0)
            {
                //rotate left

            }
            else if (Input.GetAxisRaw(rightLeftAxis) > 0)
            {
                //rotate right

            }*/
        }


        
    }
}