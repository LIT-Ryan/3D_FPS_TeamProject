using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllerM2 : MonoBehaviour
{
    public Animator anim;
    public GameObject KeyEUI2;
    public GameObject DoorNoteUI2;
    public bool keyM2;
   
    public GameObject object2;
    public float Range2;
    public LayerMask whatIslayer2;
    public bool layerInRange2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        layerInRange2 = Physics.CheckSphere(transform.position, Range2, whatIslayer2);



        if (Input.GetKeyDown(KeyCode.E) && (keyM2 == true) && (layerInRange2))
        {
            KeyEUI2.SetActive(true);
            Destroy(object2);
            anim.enabled = true;
            SoundManager.instance.doorAnimSound.Play();
        }
        else if (Input.GetKeyDown(KeyCode.E) && (keyM2 == false) && (layerInRange2))
        {
            KeyEUI2.SetActive(false);
            Time.timeScale = 0f;
            DoorNoteUI2.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.Space) && (keyM2 == false) && (layerInRange2))
        {
            Time.timeScale = 1f;
            DoorNoteUI2.SetActive(false);


        }
        if (layerInRange2 )
        {
            KeyEUI2.SetActive(true);
        }
        if (!layerInRange2)
        {
            KeyEUI2.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "KeyM2")
        {
            SoundManager.instance.keyHitDoorSound.Play();
            keyM2 = true;
        }

    }


    public void DestroyGO2()
    {
        KeyEUI2.SetActive(false);
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range2);

    }
}
