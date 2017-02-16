using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//http://catlikecoding.com/unity/tutorials/curves-and-splines/
public class RotatorAround : MonoBehaviour {
    [SerializeField]
    GameObject center;
    [SerializeField]
    float speed=10f;
	// Update is called once per frame
	void FixedUpdate () {
        transform.RotateAround(center.transform.position, Vector3.forward, speed*Time.fixedDeltaTime);
	}
}
