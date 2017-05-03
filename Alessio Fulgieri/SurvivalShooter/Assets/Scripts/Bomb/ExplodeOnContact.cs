using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnContact : MonoBehaviour {

    public float radius;
    public float damage;
	void OnTriggerEnter(Collider other)
    {
        
        Explode();
        Debug.Log(other.name);
    }
    void OnCollisionEnter(Collision other)
    {

        Explode();
        Debug.Log(other.gameObject.name);
    }
    void Explode()
    {

        Collider[] hittenObjects = Physics.OverlapSphere(transform.position,radius,LayerMask.GetMask("Shootable"));

        for(int i=0;i<hittenObjects.Length;i++)
        {
            EnemyHealth health = hittenObjects[i].GetComponent<EnemyHealth>();
            if (health != null)
            {
                health.TakeDamage((int)damage, Vector3.zero+health.transform.position);
            }
        }
        
        Destroy(gameObject);
        Debug.Log("distrutto");
    }
}
