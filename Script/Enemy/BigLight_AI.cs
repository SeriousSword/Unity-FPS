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
    private float JumpDistance = 20f;
    private float JumpDuration=4/3f;
    public Transform groundCheck;
    private float groundDistance = 0.8f;
    public LayerMask groundMask;
    bool isGrounded;
    private float DetectionRange = 1000f; // 检测范围
    private float DetectionAngle = 15f; // 检测角度
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
        if (distanceToPlayer <= detectDistance)
        {
            UpDown();
            if (isGrounded &&!animator.GetCurrentAnimatorStateInfo(0).IsName("AttackPrepare") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                FacePlayer();
                if(!RangeLock && !LightLock && animator.GetCurrentAnimatorStateInfo(0).IsName("Standing") &&IsPlayerInDetectionRange())
                {
                    Jump(JumpDistance);
                    animator.SetBool("Attack",false);
                    animator.SetBool("Up",true);
                }
                else if(RangeLock && !LightLock && animator.GetCurrentAnimatorStateInfo(0).IsName("Standing"))
                {
                    Jump(distanceToPlayer);
                    animator.SetBool("Attack",false);
                    animator.SetBool("Up",true);
                }
                else if (LightLock)
                {
                    animator.SetBool("Attack",true);
                    animator.SetBool("Up",false);
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
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 0.8f);
    }
    void Jump(float Distance)
    {
        float HorizontalSpeed = Distance / JumpDuration;

        // 计算垂直速度
        float VerticalSpeed = (2 * Physics.gravity.magnitude * JumpDuration) / 2f;

        // 设置跳跃方向和速度
        Vector3 JumpDirection = transform.forward * HorizontalSpeed + Vector3.up * VerticalSpeed;

        // 应用速度
        rb.velocity = JumpDirection;
    }
    bool IsPlayerInDetectionRange()
    {
        Vector3 DirectionToPlayer = player.position - transform.position;
        float distanceToPlayer = DirectionToPlayer.magnitude;

        if (distanceToPlayer > DetectionRange)
        {
            return false; // 超过检测范围
        }

        float angleToPlayer = Vector3.Angle(transform.forward, DirectionToPlayer);
        if (angleToPlayer < DetectionAngle / 2 )
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, DirectionToPlayer.normalized, out hit, DetectionRange))
            {
                if (hit.collider.transform == player)
                {
                    return true; // 玩家在检测范围内
                }
            }
        }
        return false; // 玩家不在检测范围内
    }
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
