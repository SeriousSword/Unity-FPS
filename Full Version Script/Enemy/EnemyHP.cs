using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    private float rate = 0.1f;
    private float FireTimer = 0f;
    public float HP = 100f;
    private float FlameDamage = 10f;
    private float RocketHitDamage = 50f;
    private float RocketExposionDamage = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <=0)
        {
            Destroy(gameObject,1);
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
    }
}
