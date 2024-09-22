using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder_AI : MonoBehaviour
{
    private float detectDistance = 1000f; // 侦测玩家的距离
    private float moveSpeed = 5f; 
    private float AttackRange = 25f;
    private Transform player;
    private Rigidbody rb;
    private Animator animator;
    public GameObject Thunder;
    private AudioSource audiosource;
    public AudioClip BreathSound;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("PlayerBody").transform;
        animator = Thunder.GetComponent<Animator>();
        audiosource.clip = BreathSound;
        audiosource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectDistance)
        {
            
            if(distanceToPlayer > AttackRange)
            {             
                FacePlayer();
                MoveTowardsPlayer();
                animator.SetBool("Moving",true);
                animator.SetBool("Attack",false);
            }
            else
            {
                FacePlayer();
                animator.SetBool("Moving",false);
                animator.SetBool("Attack",true);
                //執行攻擊行為
            }
        }
        else
        {
            animator.SetBool("Moving",false);
            animator.SetBool("Attack",false);
        }
    }
    void FacePlayer()
    {
        Vector3 directionToFace = player.position - transform.position;
        //directionToFace.y = 0; // 保持敌人在y轴上不旋转
        Quaternion targetRotation = Quaternion.LookRotation(directionToFace);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 0.8f);
    }
    void MoveTowardsPlayer()
    {
        animator.SetBool("Moving",true);
        Vector3 direction = new Vector3 (player.position.x - transform.position.x, 0f, player.position.z - transform.position.z).normalized;
        rb.velocity = direction * moveSpeed;
    }
}
