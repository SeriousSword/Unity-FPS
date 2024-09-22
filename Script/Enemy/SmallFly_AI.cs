using System.Collections;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class SmallFly_AI : MonoBehaviour
{
    private float detectDistance = 1000f; // 侦测玩家的距离
    private float moveSpeed = 15f;       // 移动速度
    private float lockDuration = 1.5f;    // 锁定持续时间
    private float dashSpeed = 25f;      // 冲刺速度
    private float AttackRange = 10f;

    private Transform player;
    private Rigidbody rb;
    private bool isDashing = false;
    private bool isLocking = false;

    public GameObject Body;
    public Animator animator;
    public GameObject AttackTrigger;
    private AudioSource audiosource;
    public AudioClip ReadySound;
    public AudioClip AttackSound;
    public GameObject Appear;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("PlayerBody").transform;
        AttackTrigger.SetActive(false);
        audiosource = GetComponent<AudioSource>();
        var expFx = Instantiate (Appear, transform.position, transform.rotation);
        Destroy(expFx, 1f);
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectDistance)
        {
            if (!isDashing && !isLocking)
            {         
                MoveTowardsPlayer();
                FacePlayer();
            }
        }
        else
        {
            // 悬停在空中
            rb.velocity = Vector3.zero;
            animator.SetBool("AttackReady",false);
            animator.SetBool("MovingReady",false);
        }
    }

    void MoveTowardsPlayer()
    {
        animator.SetBool("MovingReady",true);
        Vector3 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= AttackRange) // 距离玩家接近时开始锁定
        {
            rb.velocity = Vector3.zero;
            animator.SetBool("AttackReady",true);
            StartCoroutine(LockOnPlayer());
        }
    }

    void FacePlayer()
    {
        Vector3 directionToFace = player.position - transform.position;
        //directionToFace.y = 0; // 保持敌人在y轴上不旋转
        Quaternion targetRotation = Quaternion.LookRotation(directionToFace);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
    }

    IEnumerator LockOnPlayer()
    {
        
        isLocking = true;
        rb.velocity = Vector3.zero; // 停止移动

        float lockEndTime = Time.time + lockDuration;
        audiosource.clip = ReadySound;
        audiosource.Play();
        //Body.transform.Rotate(90,0,0);
        while (Time.time < lockEndTime)
        {
            FacePlayer();
            yield return null;
        }
        audiosource.clip = AttackSound;
        audiosource.Play();
        StartCoroutine(DashTowardsPlayer());
    }

    IEnumerator DashTowardsPlayer()
    {

        isLocking = false;
        isDashing = true;
        
        
        AttackTrigger.SetActive(true);
        Vector3 dashDirection = (player.position - transform.position).normalized;
        rb.velocity = dashDirection * dashSpeed;
        yield return new WaitForSeconds(0.5f); // 冲刺持续时间，根据需要调整

        animator.SetBool("AttackReady",false);
        
        rb.velocity = Vector3.zero; // 停止冲刺
        AttackTrigger.SetActive(false);
        rb.velocity = new Vector3(0f, 1f, 0f)*moveSpeed*0.5f;
        yield return new WaitForSeconds(2f);
        isDashing = false;
        // 悬停在空中，准备重新寻找玩家
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Rocket")
        {

        }
        else if(other.tag == "RocketRange")
        {

        }
        else if (other.tag == "flame")
        {

        }
        else
        { 
            rb.velocity = Vector3.zero;
            AttackTrigger.SetActive(false);
        }
    }
}