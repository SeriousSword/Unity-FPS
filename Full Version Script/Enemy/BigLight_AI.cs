using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class BigLight_AI : MonoBehaviour
{
    private float detectDistance = 1000f;
    private float moveSpeed = 5f;
    private float MaxRange = 50f;
    private float MinRange = 10f;
    private Transform player;
    private Rigidbody rb;
    private Animator animator;
    public GameObject BigLight;
    private float JumpDistance = 12f;
    private float JumpDuration=4/3f;
    public Transform groundCheck;
    private float groundDistance = 0.8f;
    public LayerMask groundMask;
    bool isGrounded;
    private float DetectionRange = 1000f; // æ£?æµ???????
    private float DetectionAngle = 15f; // æ£?æµ?è§?åº?
    public bool LightLock = false;
    public bool RangeLock = false;
    public GameObject GroundAttack;
    private AudioSource audiosource;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("PlayerBody").transform;
        animator = BigLight.GetComponent<Animator>();
        LightLock = false;
        RangeLock = false;
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        UpDown();
        if (isGrounded &&!animator.GetCurrentAnimatorStateInfo(0).IsName("AttackPrepare") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            FacePlayer();
            if(RangeLock && !LightLock && animator.GetCurrentAnimatorStateInfo(0).IsName("Standing") )
            {
                Jump(JumpDistance);
                animator.SetBool("Attack",false);
                animator.SetBool("Up",true);
            }/*
            else if(RangeLock && !LightLock && animator.GetCurrentAnimatorStateInfo(0).IsName("Standing"))
            {
                //Jump(distanceToPlayer);
                Jump(JumpDistance);
                animator.SetBool("Attack",false);
                animator.SetBool("Up",true);
            }*/
            else if (LightLock)
            {
                animator.SetBool("Attack",true);
                animator.SetBool("Up",false);
            }
        }
        /*
        if (distanceToPlayer <= detectDistance)
        {
            
        }
        else
        {

        }
        */
    }
    void FacePlayer()
    {
        Vector3 directionToFace = player.position - transform.position;
        directionToFace.y = 0; // ä¿???????äººå?¨yè½´ä??ä¸????è½?
        Quaternion targetRotation = Quaternion.LookRotation(directionToFace);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1.5f);
    }
    void Jump(float Distance)
    {
        float HorizontalSpeed = Distance / JumpDuration;

        // è®¡ç???????´é??åº?
        float VerticalSpeed = (2 * Physics.gravity.magnitude * JumpDuration) / 2f;

        // è®¾ç½®è·³è????¹å????????åº?
        Vector3 JumpDirection = transform.forward * HorizontalSpeed + Vector3.up * VerticalSpeed;

        // åº???¨é??åº?
        rb.velocity = JumpDirection;
    }
    /*
    bool IsPlayerInDetectionRange()
    {
        Vector3 DirectionToPlayer = player.position - transform.position;
        float distanceToPlayer = DirectionToPlayer.magnitude;

        float angleToPlayer = Vector3.Angle(transform.forward, DirectionToPlayer);
        if (angleToPlayer < DetectionAngle / 2 )
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, DirectionToPlayer.normalized, out hit, DetectionRange))
            {
                if (hit.collider.transform == player)
                {
                    return true; // ??©å®¶??¨æ??æµ??????´å??
                }
            }
        }
        return false; // ??©å®¶ä¸???¨æ??æµ??????´å??
    }*/
    void UpDown()
    {
        
        if(rb.velocity.y > 0)
        {
            animator.SetBool("Up",true);
            animator.SetBool("Down",false);
            //GroundAttack.SetActive(false);
        }
        else if(rb.velocity.y < 0)
        {
            animator.SetBool("Up",false);
            animator.SetBool("Down",true);
            //GroundAttack.SetActive(true);

        }
        else if(rb.velocity.y == 0)
        {
            animator.SetBool("Up",false);
            animator.SetBool("Down",false);
            //GroundAttack.SetActive(false);
        }
    }
}
