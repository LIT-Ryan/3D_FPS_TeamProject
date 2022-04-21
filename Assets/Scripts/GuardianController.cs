using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianController : MonoBehaviour
{
    public GameObject guardian;

    public Transform spawnPoint;

    public ThrowableSword throwSword;

    public GameObject returnSwdUI;

    public bool isCooldown;
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
        SoundManager.instance.guardianSound.Play();
        GameObject currentGuardian = Instantiate(guardian, spawnPoint.position, Quaternion.identity);
        Destroy(currentGuardian, 15f);
        //throwSword.ReturnSw();
        //throwSword.throwed = true;
       //returnSwdUI.SetActive(false);

    }






    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Enemy" && isCooldown == false)
        {
            Debug.Log("Spawn");
            StartCoroutine(Cooldown());
            isCooldown = true;
            SpawnGuardian();
        }

    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(0.5f);
        isCooldown = false;
    }
}
