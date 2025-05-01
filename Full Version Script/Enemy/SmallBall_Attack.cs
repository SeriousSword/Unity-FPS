using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBall_Attack : MonoBehaviour
{
    public GameObject AttackHitbox;
    private AudioSource audiosource;
    //public AudioClip ChargeSound;
    public AudioClip AttackSound;
    public AudioClip MoveSound;
    public AudioClip DeathSound;
    public GameObject Parent;
    public Rigidbody Fire;
    public GameObject shootpoint;
    private float speed = 10f;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerBody").transform;
        AttackHitbox.SetActive(false);
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = AttackSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnableAttackHitbox()
    {
        AttackHitbox.SetActive(true);
        audiosource.clip = AttackSound;
        audiosource.loop = false;
        audiosource.Play();

        Vector3 Direction = (player.transform.position-shootpoint.transform.position).normalized;
        Rigidbody shoot = Instantiate(Fire, shootpoint.transform.position, Quaternion.identity);
		shoot.velocity = Direction*speed;
        Physics.IgnoreCollision(transform.GetComponent<Collider>(), shoot.GetComponent<Collider>());
    }
    public void DisableAttackHitbox()
    {
        AttackHitbox.SetActive(false);
    }
    public void Death()
    {
        audiosource.clip = DeathSound;
        audiosource.loop = false;
        audiosource.Play();
        Destroy(Parent,3);
    }
    public void Move()
    {
        audiosource.clip = MoveSound;
        audiosource.loop = true;
        audiosource.Play();
    }
}
