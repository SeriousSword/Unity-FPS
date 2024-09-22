using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSmoke_AI : MonoBehaviour
{
    private float detectDistance = 1000f;
    private float moveSpeed = 10f; 
    private float SmokeRange = 10f;
    private float JumpRange = 14f;
    private Transform player;
    private Rigidbody rb;
    private Animator animator;
    public GameObject BigSmoke;
    public float test = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("PlayerBody").transform;
        animator = BigSmoke.GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        FacePlayer();
        if (distanceToPlayer <= detectDistance)
        {
            if(distanceToPlayer > JumpRange && (animator.GetCurrentAnimatorStateInfo(0).IsName("Move") ||animator.GetCurrentAnimatorStateInfo(0).IsName("Standing")))
            {
                test = 0f;
                MoveTowardsPlayer();
            }
            else if(distanceToPlayer <= SmokeRange)
            {
                animator.SetBool("Move",false);
                animator.SetBool("Smoke",true);
                animator.SetBool("Jump",false);
            }
            else if(distanceToPlayer <= JumpRange)
            {
                animator.SetBool("Move",false);
                animator.SetBool("Smoke",false);
                animator.SetBool("Jump",true);
            }
        }
        else
        {
            animator.SetBool("Move",false);
            animator.SetBool("Smoke",false);
            animator.SetBool("Jump",false);
        }
    }
    void FacePlayer()
    {
        Vector3 directionToFace = player.position - transform.position;
        directionToFace.y = 0; // 保持敌人在y轴上不旋转
        Quaternion targetRotation = Quaternion.LookRotation(directionToFace);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
    }
    void MoveTowardsPlayer()
    {
        animator.SetBool("Move",true);
        animator.SetBool("Smoke",false);
        animator.SetBool("Jump",false);
        Vector3 direction = new Vector3 (player.position.x - transform.position.x, 0f, player.position.z - transform.position.z).normalized;
        rb.velocity = direction * moveSpeed;
    }
}
