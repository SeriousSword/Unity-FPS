using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffMachine_AI : MonoBehaviour
{
    private float detectDistance = 1000f;
    private float moveSpeed = 3f; 
    private float AttackRange = 50f;
    private Transform player;
    private Rigidbody rb;
    private Animator animator;
    public GameObject BuffMachine;
    private float AttackTime = 15f;
    public float t = 0f;
    public int AttackType = 1;
    public BuffMachine_State BS;
    private AudioSource audiosource;
    public AudioClip Sound;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("PlayerBody").transform;
        animator = BuffMachine.GetComponent<Animator>();
        AttackTime = 15f;
        t = 15f;
        AttackType = 1;
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = Sound;
        audiosource.Play();
    }

    void Update()
    {
        if(BS.HP<=BS.MaxHP/2)
        {
            animator.SetInteger("Action",3);
        }
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectDistance)
        {
            if(t <AttackTime)
            {
                t += Time.deltaTime;
            }
            FacePlayer();
            if(distanceToPlayer <= AttackRange)
            {
                if(t >=AttackTime)
                {
                    animator.SetBool("Ready",true);
                    t = 0;
                }
            }
            else
            {
                animator.SetInteger("Action",0);
                if(animator.GetCurrentAnimatorStateInfo(0).IsName("Moving"))
                {
                    MoveTowardsPlayer();
                }
            }
        }
        else
        {

        }
    }

    void FacePlayer()
    {
        Vector3 directionToFace = player.position - transform.position;
        directionToFace.y = 0; // 保持敌人在y轴上不旋转
        Quaternion targetRotation = Quaternion.LookRotation(directionToFace);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1.5f);
    }
    void MoveTowardsPlayer()
    {
        Vector3 direction = new Vector3 (player.position.x - transform.position.x, 0f, player.position.z - transform.position.z).normalized;
        rb.velocity = direction * moveSpeed;
    }
}
