using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftOrRight : MonoBehaviour {


    public Transform youTrans;
    public Transform wayPointTrans;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 youtDir = youTrans.forward;
        Vector3 waypointDir = wayPointTrans.position - youTrans.position;

        Vector3 crossProduct = Vector3.Cross(youtDir, waypointDir);

        float dotProduct = Vector3.Dot(crossProduct, youTrans.up);

        if(dotProduct>0)
        {
            Debug.Log("Turn right");
        }
        else
        {
            Debug.Log("Turn left");
        }
	}

    private float DotProduct(Vector3 vec1, Vector3 vec2)
    {
        float dotProduct = vec1.x * vec2.x + vec1.y * vec2.y + vec1.z * vec2.z;

        return dotProduct;
    }
}
