using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animator doorAnim;

    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.E) && other.tag == "Player")
        {
            doorAnim.SetTrigger("DoorOpen");
        }
    }
}
