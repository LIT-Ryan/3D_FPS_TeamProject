using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SilverBullet : MonoBehaviour
{
    public GameObject bullet;
    public float damage = 10f;
    public float range = 100f;
    public float spread = 1f;
    public float fireRate = 15f;

    public Camera fpsCam;
    public Transform attackPoint;
    public float nextTimeToFire = 0f;

  


    void Start()
    {
   

    }

    // Update is called once per frame


    void Update()
    {


        if (Input.GetButtonDown("Fire1") && (Time.time >= nextTimeToFire) )
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            //ManaBar.instance.UseStamina(20);
        }

    }


    void Shoot()
    {
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log("Hit");
            targetPoint = hit.point;

            /*RedTarget target = hit.transform.GetComponent<RedTarget>();
            if (target != null)
            {
                target.TakeDamage(damage);
                
            }*/
        }
        else
        { targetPoint = ray.GetPoint(10); }

        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        currentBullet.transform.forward = directionWithSpread.normalized;
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * range, ForceMode.Impulse);
        Destroy(currentBullet, 3f);
    }
}
