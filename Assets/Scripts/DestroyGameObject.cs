using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

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
            Destroy(gameObject);
        }
        if (collis.collider.tag == "Player")
        {
            Debug.Log("Hit player");
            Destroy(gameObject);
        }

        if (collis.collider.tag == "Wall")
        {
            Debug.Log("Hit player");
            Destroy(gameObject);
        }


    }
}
