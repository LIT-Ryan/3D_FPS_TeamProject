using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    private Transform target;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void seek (Transform _target)
    {
        target = _target;

    }

    public void Die()
    {
       GameObject effectIns=(GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter(Collision collis)
    {
        if (collis.collider.tag == "Enemy")
        {
            Debug.Log("Hit enemy");
            Die();
        }
        if (collis.collider.tag == "Player")
        {
            Debug.Log("Hit player");
            Die();
        }

        if (collis.collider.tag == "Wall")
        {
            Debug.Log("Hit player");
            Die();
        }

        if (collis.collider.tag == "Ground")
        {
            Debug.Log("Hit player");
            Die();
        }

        if (collis.collider.tag == "Bullet1")
        {
            Debug.Log("Hit player");
            Die();
        }
        if (collis.collider.tag == "Untagged")
        {
            Debug.Log("Hit player");
            Die();
        }
    }
}
