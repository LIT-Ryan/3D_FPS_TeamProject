using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTimeStopParticle : MonoBehaviour
{
    private ParticleSystem particles;
    // Start is called before the first frame update
    private void Awake()
    {
        particles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    public void Explode()
    {
        particles.Play();
    }
}
