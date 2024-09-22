using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBomb_AI : MonoBehaviour
{
    private float detectDistance = 1000f; // 侦测玩家的距离
    private float moveSpeed = 8f; 
    private float AttackRange = 15f;
    private Transform player;
    private Rigidbody rb;
    private Animator animator;
    public GameObject FlyBomb;
    private float AttackCoolDown =2f;
    private float AttackTime = 0f;
    private float LockingTime= 1f;
    private bool Lock;
    private bool Locked;
    
    private AudioSource audioSource;
    public AudioClip FlySound;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("PlayerBody").transform;
        animator = FlyBomb.GetComponent<Animator>();
        Lock = false;
        Locked = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = FlySound;
        audioSource.Play();
    }

    void Update()
    {
        gameObject.transform.position = new Vector3(transform.position.x, player.position.y+6f, transform.position.z);
        Vector3 pp = new Vector3 (player.position.x, 0f, player.position.z);
        Vector3 tp = new Vector3 (transform.position.x, 0f, transform.position.z);
        float distanceToPlayer = Vector3.Distance(tp, pp);
        if (distanceToPlayer <= detectDistance)
        {     
            ForwardMove();
            if(distanceToPlayer > AttackRange && Lock == false)
            {
                FacePlayer();
                //MoveTowardsPlayer();
            }
            else if(distanceToPlayer <= AttackRange && Lock == false)
            {
                Lock = true;
                StartCoroutine(LockOnPlayer());
                //AttackTime = 0f;
                //animator.SetBool("Attack",true);
            }

            if(Locked == true)
            {
                AttackTime+=Time.deltaTime;
                if(AttackTime>=AttackCoolDown)
                {
                    Lock = false;
                    Locked = false;
                    animator.SetBool("Attack",false);
                }
            }
        }
        else
        {
            animator.SetBool("Moving",false);
        }
    }
    void MoveTowardsPlayer()
    {
        animator.SetBool("Moving",true);
        Vector3 direction = new Vector3 (player.position.x - transform.position.x, 0f, player.position.z - transform.position.z).normalized;
        rb.velocity = direction * moveSpeed;
    }
    void ForwardMove()
    {
        animator.SetBool("Moving",true);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
    }

    void FacePlayer()
    {
        Vector3 directionToFace = player.position - transform.position;
        directionToFace.y = 0; // 保持敌人在y轴上不旋转
        Quaternion targetRotation = Quaternion.LookRotation(directionToFace);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
    }
    IEnumerator LockOnPlayer()
    {
        float lockEndTime = Time.time + LockingTime;
        
        while (Time.time < lockEndTime)
        {
            FacePlayer();
            yield return null;
        }
        Locked = true;
        animator.SetBool("Attack",true);
        AttackTime = 0f;
    }
}
