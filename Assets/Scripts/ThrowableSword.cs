using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableSword : MonoBehaviour
{
    public Rigidbody sword;
    public float throwForce = 50;
    public Transform target, curve_point;
    private Vector3 old_pos;
    private bool isReturning = false;
    private float time = 0f;
    public float damage = 10f;
    public bool throwed;
    public bool throwOut;


    public GameObject guardian;
    public GameObject returnSwdUI;
    PlayerController playerPower;
    public int power = 20;
    public GameObject talisSword;
    public bool swordCalled = false;

    public GameObject crosshair2;
    public GameObject crosshairULT;
    //public Animator anim;

    public Animator SwordAnim;
    private void Start()
    {
      //  anim = GetComponent<Animator>();
    }
    void Awake()
    {
        throwed = true;
        throwOut = false;
        playerPower = FindObjectOfType<PlayerController>();

    }
    void Update()
    {
        
        if ((playerPower.currentPower <= power) && (Input.GetKeyDown(KeyCode.V)))
        {
            Debug.Log("Not Enough Power");
            
        }
        if((playerPower.currentPower >= power) && (Input.GetKeyDown(KeyCode.V)) && (swordCalled == false))
        {
            crosshairULT.SetActive(true);
            crosshair2.SetActive(true);
            talisSword.SetActive(true);
            swordCalled = true;
        }
        else if ((playerPower.currentPower >= power) && (Input.GetKeyDown(KeyCode.V)) && (swordCalled == true))
        {
            crosshairULT.SetActive(false);
            crosshair2.SetActive(false);
            talisSword.SetActive(false);
            swordCalled = false;
        }

        if ( (Input.GetButtonDown("Fire2")) && (throwed == true) && (playerPower.currentPower >= playerPower.maxPower) && (swordCalled == true))
        {
            SwordAnim.SetTrigger("Shoot");
            //throwed = false;
            //playerPower.currentPower = playerPower.currentPower - power;
            //ThrowSw();
            //guardian.SetActive(true);
            //returnSwdUI.SetActive(true);
            SoundManager.instance.throwSound.Play();
            //crosshairULT.SetActive(false);
            //anim.SetBool("bool", true);
        }
        else if (Input.GetKeyDown(KeyCode.V) && (throwOut == true) && (throwed == false) && (swordCalled == true))
        {
            SwordAnim.SetTrigger("UltRD");
            //throwed = true;
            //swordCalled = false;
            //ReturnSw();
            //returnSwdUI.SetActive(false);
           // anim.SetBool("bool", true);
        }
        else if (isReturning)
        {
            //return cal
            if (time < 1f)
            {
                sword.position = getBQCpoint(time, old_pos, curve_point.position, target.position);
                sword.rotation = Quaternion.Slerp(sword.transform.rotation, target.rotation, 100 * Time.deltaTime);
                time += Time.deltaTime;
            }
            else
            {
                ResetSw();
            }

        }

       
    }
    // throw
    void ThrowSw()
    {

        isReturning = false;
        sword.transform.parent = null;
        sword.isKinematic = false;
        sword.AddForce(Camera.main.transform.TransformDirection(Vector3.forward) * throwForce, ForceMode.Impulse);
        sword.AddTorque(sword.transform.TransformDirection(Vector3.right) * 360, ForceMode.Impulse);
        throwOut = true;

    }
    // return
    public void ReturnSw()
    {
        SoundManager.instance.swordFlySound.Play();
        time = 0f;
        old_pos = sword.position;
        isReturning = true;
        sword.velocity = Vector3.zero;
        sword.isKinematic = true;
        guardian.SetActive(false);
    }

    //reset sword
    void ResetSw()
    {

        isReturning = false;
        sword.transform.parent = transform;
        sword.position = target.position;
        sword.rotation = target.rotation;
        throwOut = false;
        StartCoroutine(CloseUI()) ;
       // anim.SetBool("bool", false);

    }

    private IEnumerator CloseUI()
    {
        //crosshairULT.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        talisSword.SetActive(false);
        crosshair2.SetActive(false);
    }

        Vector3 getBQCpoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = (uu * p0) + (2 * u * t * p1) + (tt * p2);
        return p;
    }


}
