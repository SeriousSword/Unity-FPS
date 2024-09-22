using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder_Attack : MonoBehaviour
{
    public GameObject Parent;
    public Animator animator;
    public GameObject Lighting;
    public GameObject AttackPoint1;
    public GameObject AttackPoint2;
    private AudioSource audiosource;
    public AudioClip ChargeSound;
    public AudioClip AttackSound;
    public AudioClip DeathSound;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AttackPrepare()
    {
        audiosource.clip = ChargeSound;
        audiosource.Play();
    }
    public void Attack()
    {
        audiosource.clip = AttackSound;
        audiosource.Play();
        GameObject shoot = Instantiate(Lighting, AttackPoint1.transform.position, AttackPoint1.transform.rotation);
        GameObject shoot2 = Instantiate(Lighting, AttackPoint2.transform.position, AttackPoint2.transform.rotation);
    }
    public void AttackEnd()
    {
        audiosource.Stop();
    }
    public void Death()
    {
        audiosource.clip = DeathSound;
        audiosource.Play();
        Destroy(Parent,3);
    }
}
