using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    public int maxBombs = 3;
    public float acceleration;
    public float explosionRadius;
    public float damage=30f;
    public Rigidbody bombPrefab;
    

    private float timer = 0f;

    void FixedUpdate()
    {
        
        if (Input.GetButtonDown("Fire2"))
        {
            timer = 0;
            Rigidbody bomb = Instantiate(bombPrefab, transform.position, transform.rotation);
            Vector3 direction = transform.TransformDirection(new Vector3(0, 1, 1) * acceleration);
            bomb.GetComponent<ExplodeOnContact>().radius = explosionRadius;
            bomb.GetComponent<ExplodeOnContact>().damage = explosionRadius;
            bomb.AddForce(direction, ForceMode.Impulse);
            
        }
    }
}
