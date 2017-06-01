using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehindInFront : MonoBehaviour
{

    public Transform youTrans;
    public Transform enemyTrans;


    // Update is called once per frame
    void Update()
    {
        Vector3 youForward = youTrans.forward;
        Vector3 youToEnemy = enemyTrans.position - youTrans.position;


        //float dotProduct = Vector3.Dot(youForward, youToEnemy);

        float dotProduct = DotProduct(youForward, youToEnemy);

        if (dotProduct >= 0f)
        {
            Debug.Log("InFront");

        }
        else
        {
            Debug.Log("Behind");
        }

    }

    private float DotProduct(Vector3 vec1, Vector3 vec2)
    {
        float dotProduct = vec1.x * vec2.x + vec1.y * vec2.y + vec1.z * vec2.z;

        return dotProduct;
    }
}
