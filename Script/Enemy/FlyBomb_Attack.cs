using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBomb_Attack : MonoBehaviour
{
    public Animator animator;
    public Rigidbody FlyBombBomb;
    public GameObject AttackPoint;
    public GameObject Parent;
    private AudioSource audiosource;
    public AudioClip DeathSound;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Attack()
    {
        //丟炸彈
        Rigidbody shoot = Instantiate(FlyBombBomb, AttackPoint.transform.position, AttackPoint.transform.rotation);
        //Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), shoot.GetComponent<Collider>());
        IncreaseIntParameter("Bomb");
    }
    void IncreaseIntParameter(string parameterName)
    {
        int currentValue = animator.GetInteger(parameterName);
        int newValue = currentValue + 1;
        animator.SetInteger(parameterName, newValue);
    }
    public void Death()
    {
        audiosource.clip = DeathSound;
        audiosource.Play();
        Destroy(Parent,3);
    }
}
