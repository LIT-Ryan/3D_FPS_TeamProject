using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowScript2 : MonoBehaviour
{
    public Animator SwordAnim;
    public Animator lefthandAnim;
    PlayerController playerPower;
    
    public static bool isHolding;
    // Start is called before the first frame update
    void Awake()
    {
        playerPower = FindObjectOfType<PlayerController>();
    }
    void Start()
    {
        isHolding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && playerPower.currentPower >= 30 && PlayerController.isStoping == false && DashController.isDashing == false )
        {
            if (isHolding)
            {
                lefthandAnim.SetBool("Raise", false);
                SwordAnim.SetBool("UltRD1", false);
                isHolding = false;
            }
            else
            {
                lefthandAnim.SetBool("Shoot", false);
                SwordAnim.SetBool("Shoot1", false);
                lefthandAnim.SetBool("Raise" , true);
                SwordAnim.SetBool("UltRD1" , true);
                isHolding = true;
            }
            
        }
        if (Input.GetButtonDown("Fire2") && playerPower.currentPower >= 30 && isHolding && PlayerController.isStoping == false && DashController.isDashing == false )
        {
            lefthandAnim.SetBool("Shoot", true);
            lefthandAnim.SetBool("Raise", false);
            isHolding = false;
            
            SwordAnim.SetBool("Shoot1", true);
            playerPower.currentPower = 0;
        }
    }
}
