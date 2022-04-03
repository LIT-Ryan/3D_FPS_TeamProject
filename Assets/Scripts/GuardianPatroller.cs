using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardianPatroller : MonoBehaviour
{
    public NavMeshAgent agent;
    bool patrolling;
    public Transform[] patrolTargets;
    private int destPoint;
    bool arrived;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();


    }

    // Update is called once per frame
    void Update()
    {
        if (agent.pathPending)
        {
            return;
        }
        if (patrolling)
        {


            if (agent.remainingDistance < agent.stoppingDistance)
            {
                if (!arrived)
                {
                    arrived = true;
                    StartCoroutine("GoToNextPoint");
                }
            }
            else
            {
                arrived = false;
            }
        }
        else
        {
            StartCoroutine("GoToNextPoint");
        }
    }
    IEnumerator GoToNextPoint()
    {
        if (patrolTargets.Length == 0)
        {
            yield break;
        }
        patrolling = true;
        yield return new WaitForSeconds(2f);
        arrived = false;
        agent.destination = patrolTargets[destPoint].position;
        destPoint = (destPoint + 1) % patrolTargets.Length;



    }
}
