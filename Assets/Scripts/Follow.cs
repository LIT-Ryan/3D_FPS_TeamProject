using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    public Transform Target;
    public float minModifier = 3f;
    public float maxModifier = 9f;
   
    Vector3 velocity = Vector3.zero;
    public bool isFollowing = false;
    public Rigidbody ultBall;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
       // player = GameObject.Find("PlayerObj").transform;
    }

    public void StartFollowing()
    {
        isFollowing = true;

    }

    void Update()
    {
        if ( isFollowing )
        {
            Debug.Log(" is following");
            // Vector3 targetPosition = target.TransformPoint;
            ultBall.position = Vector3.SmoothDamp(ultBall.position, Target.position, ref velocity, Time.deltaTime * Random.Range(minModifier,maxModifier) );
           

        }

    }
}
