using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class KeyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform doorTarget;

    [SerializeField] public GameObject KeyEUI;
    public Animator anim;
    public bool isKey = false;
    public float Range;
    public LayerMask whatIslayer;
    public bool layerInRange;
    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        doorTarget = GameObject.FindGameObjectWithTag("Door").transform;
    }

    // Update is called once per frame
    void Update()
    {
        layerInRange = Physics.CheckSphere(transform.position, Range, whatIslayer);

        if(layerInRange && isKey== false)
        {
            KeyEUI.SetActive(true);
        }
        if(!layerInRange)
        {
            KeyEUI.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E) && (layerInRange))
        {
            anim.enabled = false;
            Debug.Log(" Move Key");
            SoundManager.instance.collectKeySound.Play();
            agent.SetDestination(doorTarget.position);
            KeyEUI.SetActive(false);
            isKey = true;
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
