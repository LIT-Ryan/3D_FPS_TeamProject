using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -10f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool speedUp;

    public int maxPower = 50;
    public int currentPower;
    public PowerBar powerBar;

    public CharacterTimeStopParticle explosive;
    public CharacterTimeStopParticle explosive2;
    Vector3 velocity;
    public bool isGrounded;

    private TimeManager timemanager;

    public Vector3 movementVector = Vector3.zero;
    public Vector3 inputVector = Vector3.zero;

    public int maxHealth = 100;
    public int currentHealth;
    public PlayerHealthBar playerHealthBar;

    public GameObject gameOverPanel;
    public MouseLook mouseLookScript;
    public bool isOver;

    public Transform recieve;

    void Start()
    {
        currentHealth = maxHealth;
        playerHealthBar.SetMaxHealth(maxHealth);

        speedUp = false;
        timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();

        currentPower = 0;
        powerBar.SetMaxPower(maxPower);
        isOver = false;

    }

    void Update()
    {

        if (PortalTeleportal.enter == true)
        {
            transform.position = recieve.position;
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            isGrounded = true;
        }
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.z = Input.GetAxis("Vertical");

        movementVector = transform.right * inputVector.x + transform.forward * inputVector.z;

        controller.Move(movementVector * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R) && StaminaBar.instance.stamianaRegen == false) //Stop Time when R is pressed
        {
            timemanager.StopTime();
            StaminaBar.instance.UseStamina(50);
            explosive.Explode();
            explosive2.Explode();


        }
        if (timemanager.TimeIsStopped && StaminaBar.instance.stamianaRegen == true)  //Continue Time when E is pressed
        {
            timemanager.ContinueTime();


        }
       
        if (Input.GetButtonDown("Jump") && (isGrounded))
        {
            isGrounded = false;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

    
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }


    public void TakeDamage(int damage)

    {
        currentHealth -= damage;
        playerHealthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }

    }

    public void Die()
    {

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        mouseLookScript.enabled = false;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        isOver = true;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
       
        if (collisionInfo.collider.tag == "EBullet")
        {
            Debug.Log("EBullet Hit");
            TakeDamage(5);
        }
        if (collisionInfo.collider.tag == "Enemy")
        {
            Debug.Log("E Hit");
            TakeDamage(5);
        }


    }
}
