using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashController : MonoBehaviour
{
    public static bool isDashing;
    public int dashAttempts;
    private float dashStartTime;
    
    public Animator leftHandAnim;

    PlayerController playerController;
    CharacterController characterController;

    [SerializeField] ParticleSystem dashForwardParticleSystem;
    [SerializeField] ParticleSystem dashBackwardParticleSystem;
    [SerializeField] ParticleSystem dashRightParticleSystem;
    [SerializeField] ParticleSystem dashLeftParticleSystem;



    void Start()
    {
        playerController = GetComponent<PlayerController>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleDash();
       
        
    }

    void HandleDash()
    {
        bool isTryingToDash = Input.GetKeyDown(KeyCode.LeftShift);
        leftHandAnim.SetBool("Dash",isDashing);

        if (isTryingToDash && !isDashing)
        {
            if ((ManaBar.instance.currentStamina >= ManaBar.instance.usedMana) && ThrowScript2.isHolding == false && PlayerController.isStoping == false)
            {
                OnStartDash();
               
            }
        }

        if(isDashing)
        {
            SoundManager.instance.dashSound.Play();
            if (Time.time - dashStartTime <= 0.4f)
            {
                if(playerController.movementVector.Equals(Vector3.zero))
                {

                    characterController.Move(transform.forward * 30f * Time.deltaTime);
                }
                else
                {
                    characterController.Move(playerController.movementVector.normalized * 30f * Time.deltaTime);

                }
            }
            else
            {
                OnEndDash();

            }
        }


    }

    void OnStartDash()
    {
        isDashing = true;
        dashStartTime = Time.time;
        dashAttempts += 1;
        PlayDashParticles();
        ManaBar.instance.UseStamina(15);
    }

    void OnEndDash()
    {

        isDashing = false;
        dashStartTime = 0;
    }

    void PlayDashParticles()
    {

        Vector3 inputVector = playerController.inputVector;

        if ( inputVector.z > 0 && Mathf.Abs(inputVector.x) <= inputVector.z)
        {
            dashForwardParticleSystem.Play();
            return;
        }

        if ( inputVector.z < 0 && Mathf.Abs(inputVector.x) <= Mathf.Abs(inputVector.z))
        {

            dashBackwardParticleSystem.Play();
            return;
        }
         if (inputVector.x > 0)
        {
            dashRightParticleSystem.Play();
            return;

        }
        if (inputVector.x < 0)
        {
            dashLeftParticleSystem.Play();
            return;

        }
        dashForwardParticleSystem.Play();

    }



}
