using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource bulletSound;
    public AudioSource bulletImpactSound;
    public AudioSource destroySound;
    public AudioSource gamePlaySound;
    public AudioSource throwSound;
    public AudioSource swordFlySound;
    public AudioSource eButlletSound;
    public AudioSource enemyImpSound;
    public AudioSource swordAttackSound;
    public AudioSource guardianSound;
    public AudioSource levelCompleteSound;
    public AudioSource dashSound;
    public AudioSource collectPowerSound;
    public AudioSource keyHitDoorSound;
    public AudioSource doorAnimSound;
    public AudioSource collectKeySound;
    public AudioSource thunderAttackSound;
    public AudioSource magicSkillSound;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
