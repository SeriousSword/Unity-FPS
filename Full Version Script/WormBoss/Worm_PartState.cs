using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm_PartState : MonoBehaviour
{
    private float rate = 0.1f;
    private float FireTimer = 0f;
    private float FlameDamage = 20f;
    private float RocketHitDamage = 50f;
    private float RocketExposionDamage = 100f;
    private float SMGBulletDamage = 10f;
    private float MinigunBulletDamage = 20f;
    private float ShotgunShellDamage = 10f;
    public GameObject MainBody;
    private float HP;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
            MainBody.GetComponent<Worm_State>().HP-=FlameDamage;
            FireTimer = 0f;
        }        
    }
    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Rocket")
        {
            MainBody.GetComponent<Worm_State>().HP-=RocketHitDamage;
        }
        if (other.tag == "RocketRange" || other.tag == "DefenceRocket")
        {
            MainBody.GetComponent<Worm_State>().HP-=RocketExposionDamage;
        }
        if (other.tag == "SMGBullet")
        {
            MainBody.GetComponent<Worm_State>().HP-=SMGBulletDamage;
        }
        if (other.tag == "MinigunBullet")
        {
            MainBody.GetComponent<Worm_State>().HP-=MinigunBulletDamage;
        }
        if (other.tag == "ShotgunShell")
        {
            MainBody.GetComponent<Worm_State>().HP-=ShotgunShellDamage;
        }
    }
}
