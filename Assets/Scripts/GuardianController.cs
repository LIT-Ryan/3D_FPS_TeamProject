using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianController : MonoBehaviour
{
    public GameObject guardian;

    public Transform spawnPoint;

    public ThrowableSword throwSword;

    //public GameObject returnSwdUI;

    Animator anim;

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
        Destroy(currentGuardian, 5f);
        throwSword.ReturnSw();
        throwSword.throwed = true;
       // returnSwdUI.SetActive(false);

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
