using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianAttackController : MonoBehaviour
{
    public GameObject guardian;

    public Transform spawnPoint;






    void Start()
    {


    }


    // Update is called once per frame
    void Update()
    {


    }

    void SpawnGuardian()
    {

        GameObject currentGuardian = Instantiate(guardian, spawnPoint.position, Quaternion.identity);
        Destroy(currentGuardian, 1f);
      

    }






    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Enemy")
        {
            Debug.Log("Spawn");
            SpawnGuardian();
        }

    }
}
