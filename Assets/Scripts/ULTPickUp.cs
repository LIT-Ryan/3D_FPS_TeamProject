using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ULTPickUp : MonoBehaviour
{
    PlayerController playerPower;
    public int powerBonus = 25;
    public GameObject dropLoop;

    void Awake()
    {
        playerPower = FindObjectOfType<PlayerController>();

    }
    void OnTriggerEnter(Collider col)

    {
        if ((playerPower.currentPower < playerPower.maxPower) && (col.gameObject.CompareTag("Player")))

        {
            Debug.Log(" ult destroy");

            // LevelManager.instance.powerSound.Play();
            Destroy(dropLoop);
            playerPower.currentPower = playerPower.currentPower + powerBonus;


        }


    }
}
