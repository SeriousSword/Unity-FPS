using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SmallBall_AI : MonoBehaviour
{
    private float detectDistance = 1000f; // 侦测玩家的距离
    private float moveSpeed = 15f;       // 移动速度
    private float AttackRange = 50f;
    private Transform player;
    public Animator animator;
    private Rigidbody rb;
    public GameObject SmallBall;
    private AudioSource audiosource;
    public AudioClip BornSound;
    private float AttackTime = 5f;
    private float CountTime = 0f;
    //public AudioClip MoveSound;
    //private NavMeshAgent navAgent;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("PlayerBody").transform;
        animator = SmallBall.GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = BornSound;
        audiosource.Play();
        CountTime = 0f;
        AttackTime = 3f;
        //navAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectDistance)
        {
            if(CountTime<AttackTime)
            {
                CountTime+=Time.deltaTime;
            }
            if (distanceToPlayer <= AttackRange &&CountTime>=AttackTime) 
            {
                StartCoroutine(Attack());
                CountTime = 0;
            }
            else 
            {
                FacePlayer();
                MoveTowardsPlayer();
                animator.SetBool("Attack",false);
            }
        }
        else//閒置狀態
        {
            animator.SetBool("FightState",false);
            animator.SetBool("Attack",false);
            transform.position =transform.position;
            transform.rotation =transform.rotation;
        }
    }
    void FacePlayer()
    {
        Vector3 directionToFace = player.position - transform.position;
        //directionToFace.y = 0; // 保持敌人在y轴上不旋转
        Quaternion targetRotation = Quaternion.LookRotation(directionToFace);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1f);
    }
    void MoveTowardsPlayer()
    {
        animator.SetBool("FightState",true);
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer > AttackRange &&!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) 
        {
            Vector3 direction = (player.position - transform.position).normalized;
            direction.y = 0;
            rb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
            //transform.position += direction * moveSpeed * Time.deltaTime;
        }
        
    }
    IEnumerator Attack()
    {
        audiosource.Stop();
        FacePlayer();
        transform.position = transform.position;
        animator.SetBool("Attack",true);
        yield return new WaitForSeconds(1.5f);
    }

}
