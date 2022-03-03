using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    GameObject cam;
   
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindWithTag("MainCamera");
    }


    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.transform.forward);
    }
}

