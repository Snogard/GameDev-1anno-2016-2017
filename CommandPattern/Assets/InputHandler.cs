﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxisRaw("Horizontal")==1)
        {

        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {

        }
        if (Input.GetAxisRaw("Vertical") == 1)
        {

        }
        if (Input.GetAxisRaw("Vertical") == -1)
        {

        }
    }
}
