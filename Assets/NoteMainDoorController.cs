using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMainDoorController : MonoBehaviour
{
    public GameObject mainDoorNotePanel;
    public bool isNote = false;

    private void Update()
    {
       if ((Input.GetKeyDown(KeyCode.Space)) && (isNote == true))
                {
            mainDoorNotePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player") && (isNote== false))
        {
            mainDoorNotePanel.SetActive(true);
            isNote = true;
            Time.timeScale = 0f;
        } 

       
    }
}
