using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTester : MonoBehaviour
{
    public Animator objAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            objAnimator.SetTrigger("Shoot");
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            objAnimator.SetTrigger("Shoot2");
        }
    }

    
}
