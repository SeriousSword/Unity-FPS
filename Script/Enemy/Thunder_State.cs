using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder_State : MonoBehaviour
{
    private float rate = 0.1f;
    private float FireTimer = 0f;
    private float HP = 320f;
    private float FlameDamage = 15f;
    private float RocketHitDamage = 80f;
    private float RocketExposionDamage = 150f;
    private float SMGBulletDamage = 10f;
    private float MinigunBulletDamage = 20f;
    private float ShotgunShellDamage = 10f;
    private AudioSource audiosource;
    private Animator animator;
    public GameObject Thunder;
    public Thunder_AI Sc;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        animator = Thunder.GetComponent<Animator>();
    }

    void Update()
    {
        if (HP <=0)
        {
            Sc.enabled = false;
            animator.Play("Death");
        }
        if (FireTimer<=rate)
        {
            FireTimer += Time.deltaTime;
        }
    }

    void OnTriggerStay(Collider other) 
    {
        if (other.tag == "flame")
        {
            if (FireTimer<=rate)
            {
                return;
            }
            HP-=FlameDamage;
            FireTimer = 0f;
        }        
    }
    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Rocket")
        {
            HP-=RocketHitDamage;
        }
        if (other.tag == "RocketRange")
        {
            HP-=RocketExposionDamage;
        }
        if (other.tag == "SMGBullet")
        {
            HP-=SMGBulletDamage;
        }
        if (other.tag == "MinigunBullet")
        {
            HP-=MinigunBulletDamage;
        }
        if (other.tag == "ShotgunShell")
        {
            HP-=ShotgunShellDamage;
        }
    }
}
