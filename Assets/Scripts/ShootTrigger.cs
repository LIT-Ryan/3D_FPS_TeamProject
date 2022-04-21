using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTrigger : MonoBehaviour
{
    public GameObject appearObj;
    public Animator appearAnim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            appearObj.SetActive(true);
            appearAnim.SetTrigger("Trigger");
        }
      
    }

}
