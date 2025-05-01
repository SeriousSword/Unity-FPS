using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10f;//移動速度
    public float gravity = -9.81f;//重力

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public bool DashAllow = true; 
    private bool Dashing = false; 
    public float DashTime = 0.2f;
    public float DashCoolDownTime = 1f;
    private float DashPower = 30f;
    private bool DashGround = true;

    private float DoubleJump = 0f;//0f = grounded ,1f = one jump,2f = two jump

    private AudioSource audiosource;
    public AudioClip MoveSound;
    public AudioClip JumpSound;
    public AudioClip DashSound;
    private KeyCode JumpKey = KeyCode.Space;
    private KeyCode DashKey = KeyCode.LeftShift;
    public float x;
    public float z;
    void Start() 
    {
        audiosource = GetComponent<AudioSource>();
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        x = Input.GetAxisRaw("Horizontal");//input水平
        z = Input.GetAxisRaw("Vertical");//input垂直
        
        //重力
        if(isGrounded && velocity.y<0)
        {
            velocity.y = -9.81f;
        
        }

        //二段跳
        if (isGrounded)
        {
            DoubleJump = 0f;
        }
        
        if (Input.GetKeyDown(JumpKey) && DoubleJump == 0f)
        {
            velocity.y = 6f;
            DoubleJump = 1f;
            audiosource.clip = JumpSound;
            audiosource.Play();
        }
        if (Input.GetKeyDown(JumpKey)  && DoubleJump == 1f)
        {
            velocity.y = 6f;
            DoubleJump = 2f;
            audiosource.clip = JumpSound;
            audiosource.Play();
        }

        //垂直
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        Vector3 move = (transform.right * x + transform.forward * z).normalized;

        if (DashGround && isGrounded)//到了地面才能冷卻完成
        {
            DashAllow = true;
        }
        if (Input.GetKeyDown(DashKey) && DashAllow == true)
        {
            StartCoroutine(Dash());
        }
        //移動
        if (!Dashing)
        {
            controller.Move(move * speed * Time.deltaTime);
        }
        
    }
    
    private IEnumerator Dash()
    {
        float x = Input.GetAxisRaw("Horizontal");//input水平
        float z = Input.GetAxisRaw("Vertical");//input垂直
        audiosource.clip = DashSound;
        audiosource.Play();
        DashAllow = false;
        DashGround = false;
        Dashing = true;
        float GravitySave = gravity;
        gravity = 0f;
        

        Vector3 move = (transform.right * x + transform.forward * z).normalized;
        velocity = new Vector3(move.x*DashPower*transform.lossyScale.x , 0 , move.z*DashPower*transform.lossyScale.z);
        yield return new WaitForSeconds(DashTime);
        velocity = new Vector3(0f,0f,0f);
        gravity = GravitySave ;
        Dashing = false;
        yield return new WaitForSeconds(DashCoolDownTime);
        DashGround = true; 
    }
}