using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundExplode_AI : MonoBehaviour
{
    private float detectDistance = 1000f;
    private Transform player;
    private Rigidbody rb;
    private Animator animator;
    public GameObject GroundExplode;
    private float AttackRange = 40f;
    public GroundExplode_State Sc;
    private float DetectionRange = 1000f; 
    private float DetectionAngle = 60f;
    public bool RangeLock;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("PlayerBody").transform;
        animator = GroundExplode.GetComponent<Animator>();
        RangeLock = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectDistance)
        {
            IsPlayerInDetectionRange();
            if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Move"))
            {
                FacePlayer();
            }
            if(distanceToPlayer <= AttackRange &&Sc.HP>Sc.MaxHP/2 && RangeLock == true)
            {
                animator.SetInteger("Action",2);
            }
            else if(distanceToPlayer <= AttackRange &&Sc.HP<=Sc.MaxHP/2 &&RangeLock == true)
            {
                animator.SetInteger("Action",3);
            }
            if(distanceToPlayer > AttackRange && RangeLock == true)
            {
                animator.SetInteger("Action",1);
            }
            
        }
    }
    void FacePlayer()
    {
        Vector3 directionToFace = player.position - transform.position;
        directionToFace.y = 0; // 保持敌人在y轴上不旋转
        Quaternion targetRotation = Quaternion.LookRotation(directionToFace);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 0.8f);
    }
    bool IsPlayerInDetectionRange()
    {
        Vector3 DirectionToPlayer = player.position - transform.position;
        float distanceToPlayer = DirectionToPlayer.magnitude;

        if (distanceToPlayer > DetectionRange)
        {
            Debug.Log("false");
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
}
