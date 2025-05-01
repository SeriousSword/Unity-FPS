using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Worm_State : MonoBehaviour
{
    private float rate = 0.1f;
    private float FireTimer = 0f;
    public UnityEngine.UI.Image HPbar;
    public float HP = 12000f;
    
    private float MaxHP = 12000f;

    private float FlameDamage = 20f;
    private float RocketHitDamage = 50f;
    private float RocketExposionDamage = 100f;
    private float SMGBulletDamage = 10f;
    private float MinigunBulletDamage = 20f;
    private float ShotgunShellDamage = 10f;
    private AudioSource audiosource;
    public AudioClip Death;
    public GameObject Player;
    public GameObject DestroyParticle;
    private Animator animator;
    private bool DeathCheck = false;
    
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        animator = gameObject.GetComponent<Animator>();
        DestroyParticle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        HPbar.fillAmount =HP/MaxHP;

        if (HP <=0 && !DeathCheck)
        {
            //Player.SetActive(false);
            DeathCheck = true;
            gameObject.GetComponent<Worm_AI>().enabled = false;
            animator.Play("Death",-1,0f);
            DestroyParticle.SetActive(true);
            
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
    void DeathEvent()
    {
        StartCoroutine(BossEnd());
    }
    
    IEnumerator BossEnd()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadSceneAsync(0);
    }
}
