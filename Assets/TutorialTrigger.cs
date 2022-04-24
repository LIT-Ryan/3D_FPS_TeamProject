using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public GameObject UIObj;
    public static bool tutoring = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(Cooldown());
            UIObj.SetActive(false);
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            tutoring = true;
            UIObj.SetActive(true);
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(0.5f);
        tutoring = false;
    }
}
