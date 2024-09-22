using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigLight_Attack : MonoBehaviour
{
    public Animator animator;
    public GameObject Lighting;
    public GameObject Parent;
    public GameObject GroundAttack;
    private Collider GAC;
    private AudioSource audiosource;
    public AudioClip ChargeSound;
    public AudioClip DeathSound;
    public AudioClip ShootSound;
    public AudioClip MoveSound;
    public AudioClip JumpSound;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        GAC = GroundAttack.GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Death()
    {
        audiosource.clip = DeathSound;
        audiosource.Play();
        Destroy(Parent,3);
    }
    public void Attack()
    {
        audiosource.clip = ShootSound;
        audiosource.Play();
        Lighting.SetActive(true);
    }
    public void AttackEnd()
    {
        audiosource.Stop();
        Lighting.SetActive(false);
        animator.SetBool("Attack",false);
    }
    public void DownAttack()
    {
        GAC.enabled=true;
    }
    public void AttackPrepare()
    {
        audiosource.clip = ChargeSound;
        audiosource.Play();
    }
    public void Jump()
    {
        audiosource.clip = JumpSound;
        audiosource.Play();
    }
    public void Normal()
    {
        audiosource.clip = MoveSound;
        audiosource.Play();
    }
}
