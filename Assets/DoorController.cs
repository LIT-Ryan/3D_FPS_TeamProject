using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator anim;
    public GameObject KeyEUI;
    public GameObject DoorNoteUI;
    public bool keyM1;
 
    public GameObject object1;
    public float Range;
    public LayerMask whatIslayer;
    public bool layerInRange;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        layerInRange = Physics.CheckSphere(transform.position, Range, whatIslayer);



        if (Input.GetKeyDown(KeyCode.E) && (keyM1 == true) && (layerInRange))
        {
            KeyEUI.SetActive(true);
            Destroy(object1);
            anim.enabled = true;
            SoundManager.instance.doorAnimSound.Play();
        }
        else if (Input.GetKeyDown(KeyCode.E) && (keyM1 == false) && (layerInRange))
        {
            KeyEUI.SetActive(false);
            Time.timeScale = 0f;
            DoorNoteUI.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.Space) && (keyM1 == false) && (layerInRange))
        {
            Time.timeScale = 1f;
            DoorNoteUI.SetActive(false);
          

        }
        if(layerInRange )
        {
            KeyEUI.SetActive(true);
          
        }
        if(!layerInRange)
        {
            KeyEUI.SetActive(false);
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.tag == "Key")
        {
            SoundManager.instance.keyHitDoorSound.Play();
            keyM1 = true;
        }

    }


    public void DestroyGO()
    {
        KeyEUI.SetActive(false);
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);

    }
}
