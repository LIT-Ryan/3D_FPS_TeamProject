using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class KeyController2 : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform doorTarget2;

    [SerializeField] public GameObject KeyEUI2;
    public Animator anim2;
    public bool isKey2 = false;
    public float Range2;
    public LayerMask whatIslayer2;
    public bool layerInRange2;
    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        doorTarget2 = GameObject.FindGameObjectWithTag("Door2").transform;
    }

    // Update is called once per frame
    void Update()
    {
        layerInRange2 = Physics.CheckSphere(transform.position, Range2, whatIslayer2);

        if (layerInRange2 && isKey2 == false)
        {
            KeyEUI2.SetActive(true);
        }
        if (!layerInRange2)
        {
            KeyEUI2.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E) && (layerInRange2))
        {
            anim2.enabled = false;
            Debug.Log(" Move Key");
            SoundManager.instance.collectKeySound.Play();
            agent.SetDestination(doorTarget2.position);
            KeyEUI2.SetActive(false);
            isKey2 = true;
        }

    }

    void GotoTarget()
    {

    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range2);

    }
}
