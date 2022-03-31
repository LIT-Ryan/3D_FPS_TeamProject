using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public int maxHealth = 30;
    public int currentHealth;
    public EnemyHealthBar enemyHealthBar;

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask WhatIsGround, whatIsPlayer;



   
    private TimeManager timemanager;
    public bool isStoped;
    //patroling

   // public Vector3 walkpoint;
    bool walkPointSet;
   // public float walkPointRange;

    public Patroller patroller;

    //Attackting
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public GameObject projecttile;

    public Transform attackPoint;
    GameObject dropLootTarget;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public GameObject DropLootPrefab;
    public GameObject stopCover;

    public Animator theAnimator;
   
    public GameObject impactEffectEnemyDie;

    private void Awake()
    {
        player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<NavMeshAgent>();

       
    }

    // Start is called before the first frame update
    void Start()
    {

        currentHealth = maxHealth;
        enemyHealthBar.SetMaxHealth(maxHealth);
        timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();

        dropLootTarget = GameObject.FindWithTag("DropLootTraker");
      
    }
    public void TakeDamage(int damage)

    {
        currentHealth -= damage;
        enemyHealthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        
        GameObject effectInst = (GameObject)Instantiate(impactEffectEnemyDie, transform.position, transform.rotation);
        Destroy(effectInst, 2f);
        Destroy(gameObject);
        GameObject ultBall = Instantiate(DropLootPrefab, transform.position, Quaternion.identity);
        ultBall.GetComponent<Follow>().Target = dropLootTarget.transform;
        Destroy(ultBall, 3f) ;
    }

    // Update is called once per frame
    void Update()
    {

        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

    
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();

        if(!playerInSightRange && !playerInAttackRange)
        {
            patroller.enabled = true;
        }
        /// TIME STOP
        if (!timemanager.TimeIsStopped)
        {
            // agent.SetDestination(player.transform.position);  //go to player

            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), 10f * Time.deltaTime); //Look at player
                //anim.Play("Attack");
            }
        }
        if (timemanager.TimeIsStopped)
        {
            agent.velocity = Vector3.zero; // stop moving
            isStoped = true;
            // anim.speed = 0f;  //stop the animation
            stopCover.SetActive(true); 
        }
        else
        {
            //anim.speed = 1f;
            isStoped = false;
            stopCover.SetActive(false);

        }

        return;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Guardian")
        {
            Debug.Log("Guardian Hit");
            TakeDamage(30);
        }
        if (collisionInfo.collider.tag == "Bullet")
        {
            Debug.Log("Bullet1 Hit");
            TakeDamage(5);
        }
        if (collisionInfo.collider.tag == "MagicBullet")
        {
            Debug.Log("Bullet1 Hit");
            TakeDamage(10);
        }

    }

   
    private void ChasePlayer()

    {
        agent.SetDestination(player.position);
        patroller.enabled = false;

    }


    private void AttackPlayer()

    {
        patroller.enabled = false;
        theAnimator.SetBool("Attack", true);
        //make sure enemy does not move
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            // attack code

            GameObject rb = Instantiate(projecttile, attackPoint.position, Quaternion.identity);
            rb.GetComponent<Rigidbody>().AddForce(transform.forward * 25f, ForceMode.Impulse);
            rb.GetComponent<Rigidbody>().AddForce(transform.up * 8f, ForceMode.Impulse);
            theAnimator.SetBool("Attack", true);



            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            Destroy(rb, 2f);


            // Destroy(this.gameObject, GetComponent<ParticleSystem>().main.duration);
        }
        else { theAnimator.SetBool("Attack", false); }

    }


    private void ResetAttack()
    {
        alreadyAttacked = false;

      
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }


}
