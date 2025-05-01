using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WormBody_State : MonoBehaviour
{
    private float rate = 0.1f;
    private float FireTimer = 0f;
    public UnityEngine.UI.Image HPbar;
    public GameObject HPbarObject;
    public float HP = 4000f;
    
    private float MaxHP = 4000f;
    private float EnemyComingHP1 =3000f;
    private float EnemyComingHP2 =2000f;
    private float EnemyComingHP3 =1000f;
    public GameObject EnemyWave1;
    public GameObject EnemyWave2;
    public GameObject EnemyWave3;
    private float FlameDamage = 20f;
    private float RocketHitDamage = 50f;
    private float RocketExposionDamage = 100f;
    private float SMGBulletDamage = 10f;
    private float MinigunBulletDamage = 20f;
    private float ShotgunShellDamage = 10f;
    private AudioSource audiosource;
    public GameObject gateR;
    public GameObject gateL;
    
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        HPbar.fillAmount =HP/MaxHP;
        if (HP <=0)
        {
            gateL.GetComponent<OpenGate>().enabled=true;
            gateR.GetComponent<OpenGate>().enabled=true;
            Destroy(HPbarObject);
            Destroy(gameObject,1);
        }
        else if(HP <=EnemyComingHP3)
        {
            EnemyWave3.SetActive(true);
        }
        else if(HP <=EnemyComingHP2)
        {
            EnemyWave2.SetActive(true);
        }
        else if(HP <=EnemyComingHP1)
        {
            EnemyWave1.SetActive(true);
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
        if (other.tag == "RocketRange" || other.tag == "DefenceRocket")
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
    }/*
    void OnDestroy()
    {
        gateL.GetComponent<OpenGate>().enabled=true;
        gateR.GetComponent<OpenGate>().enabled=true;
    }*/
}
