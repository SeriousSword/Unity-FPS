using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthDedense : MonoBehaviour
{
    private float rate = 0.1f;
    private float FireTimer = 0f;
    public float HP = 3000f;
    public float MaxHP = 3000f;
    private float FlameDamage = 20f;
    private float RocketHitDamage = 50f;
    private float RocketExposionDamage = 100f;
    private float SMGBulletDamage = 10f;
    private float MinigunBulletDamage = 20f;
    private float ShotgunShellDamage = 10f;
    private AudioSource audiosource;
    public AudioClip Earth;
    public AudioClip Break;
    private bool DeathEnd =false;
    public UnityEngine.UI.Image SPbar;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = Earth;
        audiosource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        SPbar.fillAmount=HP/MaxHP;
        if (HP <=0 && !DeathEnd)
        {
            Destroy(gameObject,1);
            DeathEnd = true;
            audiosource.clip = Break;
            audiosource.Play();
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
    }
}
