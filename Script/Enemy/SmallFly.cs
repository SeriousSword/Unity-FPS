using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class SmallFly : MonoBehaviour
{
    private float rate = 0.1f;
    private float FireTimer = 0f;
    private float HP = 50f;
    private float FlameDamage = 15f;
    private float RocketHitDamage = 80f;
    private float RocketExposionDamage = 150f;
    private float SMGBulletDamage = 10f;
    private float MinigunBulletDamage = 20f;
    private float ShotgunShellDamage = 10f;
    public GameObject explosion;
    void Start()
    {
        
    }
    void Update()
    {
        if (HP <=0)
        {
            var expFx = Instantiate (explosion, transform.position, transform.rotation);
            Destroy(expFx, 1);
            Destroy(gameObject);
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
