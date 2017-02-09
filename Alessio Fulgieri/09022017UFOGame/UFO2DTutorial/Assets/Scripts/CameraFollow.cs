using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private Transform playerTranform;
    /// <summary>
    /// 
    /// </summary>
    private Vector3 _offset;

	// Use this for initialization
	void Start ()
    {
        _offset = transform.position - playerTranform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () //  è come un update ma viene chiamato dopo che tutti gli altri update sono stati eseguiti
    {
        transform.position = playerTranform.position + _offset;
	}
}
