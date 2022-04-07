using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    private Transform target;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void seek (Transform _target)
    {
        target = _target;

    }

    public void Die()
    {
        //SoundManager.instance.destroySound.Play();
        GameObject effectIns=(GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 1f);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter(Collision collis)
    {
        if (collis.collider.tag == "Enemy")
        {
            SoundManager.instance.bulletImpactSound.Play();
          
            Die();
        }
        if (collis.collider.tag == "Player")
        {
            SoundManager.instance.bulletImpactSound.Play();
          
            Die();
        }

        if (collis.collider.tag == "Wall")
        {
            SoundManager.instance.bulletImpactSound.Play();
           
            Die();
        }

        if (collis.collider.tag == "Ground")
        {
            SoundManager.instance.bulletImpactSound.Play();
       
            Die();
        }

        if (collis.collider.tag == "Bullet1")
        {
            SoundManager.instance.bulletImpactSound.Play();
          
            Die();
        }
        if (collis.collider.tag == "Untagged")
        {
            SoundManager.instance.bulletImpactSound.Play();
        
            Die();
        }
        if (collis.collider.tag == "Door")
        {
            SoundManager.instance.bulletImpactSound.Play();
          
            Die();
        }
        if (collis.collider.tag == "Door2")
        {
            SoundManager.instance.bulletImpactSound.Play();
       
            Die();
        }
        if (collis.collider.tag == "Key")
        {
            SoundManager.instance.bulletImpactSound.Play();

            Die();
        }
        if (collis.collider.tag == "KeyM2")
        {
            SoundManager.instance.bulletImpactSound.Play();

            Die();
        }
    }
}
