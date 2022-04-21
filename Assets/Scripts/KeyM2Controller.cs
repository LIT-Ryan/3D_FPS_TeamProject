using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class KeyM2Controller : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform doorTarget_m2;

    public GameObject KeyEUI_M2;
    public Animator anim_2;
    public bool isKey_2 = false;
    public float Range;
    public LayerMask whatIslayer;
    public bool layerInRange;
    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        doorTarget_m2 = GameObject.FindGameObjectWithTag("DoorM2").transform;
    }
    private void Start()
    {
      

    }
    // Update is called once per frame
    void Update()
    {
        layerInRange = Physics.CheckSphere(transform.position, Range, whatIslayer);

        if (layerInRange && isKey_2 == false)
        {
            KeyEUI_M2.SetActive(true);
        }
        if (!layerInRange)
        {
            KeyEUI_M2.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E) && (layerInRange))
        {
            anim_2.enabled = false;
            Debug.Log(" Move Key");

            agent.SetDestination(doorTarget_m2.position);
            KeyEUI_M2.SetActive(false);
            isKey_2 = true;
        }

    }

    void GotoTarget()
    {

    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);

    }
}

