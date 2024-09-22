using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSmoke_Attack : MonoBehaviour
{
    public Animator animator;
    public GameObject Parent;
    private GameObject[] SmokeAttack;
    public GameObject Jump;
    private AudioSource audiosource;
    public AudioClip SteamSound;
    public AudioClip JumpSound;
    public AudioClip MoveSound;
    public AudioClip StandingSound;
    public AudioClip DeathSound;
    
    void Start()
    {
        Jump.SetActive(false);
        audiosource = GetComponent<AudioSource>();
        SmokeAttack = GameObject.FindGameObjectsWithTag("BigSmokeSmokeAttack");
        audiosource = GetComponent<AudioSource>();
        foreach (GameObject obj in SmokeAttack)
        {
            obj.SetActive(false);
        }
    }
    void Update()
    {
        
    }
    public void SmokeStart()
    {
        audiosource.clip = SteamSound;
        audiosource.Play();
        foreach (GameObject obj in SmokeAttack)
        {
            obj.SetActive(true);
        }
    }
    public void SmokeEnd()
    {
        audiosource.Stop();
        foreach (GameObject obj in SmokeAttack)
        {
            obj.SetActive(false);
        }
    }
    public void JumpStart()
    {
        audiosource.clip = JumpSound;
        audiosource.Play();
        Jump.SetActive(true);
    }
    public void JumpEnd()
    {
        Jump.SetActive(false);
    }
    public void Death()
    {
        audiosource.clip = DeathSound;
        audiosource.Play();
        Destroy(Parent,3);
    }
    public void Move()
    {
        audiosource.clip = MoveSound;
        audiosource.Play();
    }
    public void Standing()
    {
        audiosource.clip = StandingSound;
        audiosource.Play();
    }
}
