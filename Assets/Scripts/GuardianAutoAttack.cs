using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardianAutoAttack : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform enemy;
    [Header("Attributes")]

    public float attackRange = 15f;
    public float timeBetweenAttacks;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject thunderAttack;
    public Transform attackPoint;
    

   public GuardianPatroller guardianPatroler;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    private void Awake()
    {

        agent = GetComponent<NavMeshAgent>();


    }
    void UpdateTarget()
    {


        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject etarget in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, etarget.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = etarget;
            }
        }
        if (nearestEnemy != null && shortestDistance <= attackRange)
        {
            enemy = nearestEnemy.transform;
            
            
        }
 
    }


  

    // Update is called once per frame
    void Update()
    {
        if (enemy == null) return;

        Vector3 dir = enemy.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(rotation.z, rotation.y, rotation.z); // lookRotation;

        if (fireCountdown <= 0f)
        {

            AttackEnemy();
            fireCountdown = 1f / timeBetweenAttacks;
        }
        fireCountdown -= Time.deltaTime;

    }

   

    private void AttackEnemy()

    {
        GameObject bulletGO = (GameObject)Instantiate(thunderAttack, attackPoint.position, attackPoint.rotation);
        SwordAttack bullet = bulletGO.GetComponent<SwordAttack>();



        if (bullet != null)
            bullet.Seek(enemy);

        Destroy(bullet, 2f);
    }


  private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

    }



}



  