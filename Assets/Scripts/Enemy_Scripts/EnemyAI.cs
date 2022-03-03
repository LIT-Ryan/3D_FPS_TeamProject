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

    public Vector3 walkpoint;
    bool walkPointSet;
    public float walkPointRange;

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
        Destroy(gameObject);
        GameObject ultBall = Instantiate(DropLootPrefab, transform.position, Quaternion.identity);
        ultBall.GetComponent<Follow>().Target = dropLootTarget.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();

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
            TakeDamage(15);
        }

    }

    private void patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkpoint);
        Vector3 distanceToWalkPoint = transform.position - walkpoint;

        // walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

    }


    private void SearchWalkPoint()

    {
        // Calcultate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkpoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkpoint, -transform.up, 2f, WhatIsGround))
            walkPointSet = true;
    }
    private void ChasePlayer()

    {
        agent.SetDestination(player.position);


    }


    private void AttackPlayer()

    {
        //make sure enemy does not move
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if(!alreadyAttacked )
        {
            // attack code

            GameObject rb = Instantiate(projecttile, attackPoint.position, Quaternion.identity);
            rb.GetComponent<Rigidbody>().AddForce(transform.forward * 8f, ForceMode.Impulse);
            rb.GetComponent<Rigidbody>().AddForce(transform.up * 5f, ForceMode.Impulse);
            
            


            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            Destroy(rb,2f);


            // Destroy(this.gameObject, GetComponent<ParticleSystem>().main.duration);
        }

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
