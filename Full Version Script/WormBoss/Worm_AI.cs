using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm_AI : MonoBehaviour
{
    public GameObject RightPoint;
    public GameObject LeftPoint;
    public GameObject MiddlePoint;
    public GameObject RightImpactPoint;
    public GameObject LeftImpactPoint;
    private float Speed = 15f;
    private float ShootSpeed = 30f;
    private Animator animator;
    private AudioSource audiosource;
    public AudioClip NormalSound;
    public AudioClip ForwardThrustSound;
    public AudioClip ImpactSound;
    private Transform player;
    public int Local = 2;//1=右，2=左，3=中
    public int Action = 1;//0=非攻擊，1=前撞，2=射擊，3=從右撞，4=從左撞
    public bool ImpactCheck = false;
    public GameObject RightGate;
    public GameObject LeftGate;
    private float T = 0f;
    private float ActiveStateTime = 10f;
    public GameObject ForwardTrig;
    public GameObject[] SideTrig;
    public Rigidbody ShootProjectile;
    public GameObject shootpoint;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerBody").transform;
        animator = gameObject.GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
        ForwardTrig.SetActive(false);
        foreach(GameObject obj in SideTrig)
        {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Breath"))
        {
            ThreeLocationMove();
            audiosource.loop = true;
            if(audiosource.clip != NormalSound)
            {
                audiosource.clip = NormalSound;
                audiosource.Play();
            }
        }
        else 
        {
            audiosource.loop = false;
        }
    }
    void ActiveChange()
    {
        animator.SetInteger("Action",0);
        Local = Random.Range(1, 4);
        if(Local == 1)
        {
            int[] Num ={1,2,3};
            Action =Num[Random.Range(0, 3)];
        }
        else if(Local == 2)
        {
            int[] Num ={1,2,4};
            Action =Num[Random.Range(0, 3)];
        }
        else if(Local == 3)
        {
            int[] Num ={1,2};
            Action =Num[Random.Range(0, 2)];
        }
        
    }
    void ForwardAttackColliderActive()
    {
        ForwardTrig.SetActive(true);
        audiosource.clip =ForwardThrustSound;
        audiosource.Play();
    }
    void ForwardAttackColliderClose()
    {
        ForwardTrig.SetActive(false);
        ActiveChange();
    }
    void RightAttackColliderActive()
    {
        foreach(GameObject obj in SideTrig)
        {
            obj.SetActive(true);
        }
        audiosource.clip =ImpactSound;
        audiosource.Play();
    }
    void RightAttackColliderClose()
    {
        foreach(GameObject obj in SideTrig)
        {
            obj.SetActive(false);
        }
        if(LeftGate.GetComponent<BossDoor>().Ent == true)
        {
            LeftGate.GetComponent<BossDoor>().Ent = false;
            LeftGate.GetComponent<AudioSource>().Play();
        }
        ActiveChange();
    }
    void LeftAttackColliderActive()
    {
        foreach(GameObject obj in SideTrig)
        {
            obj.SetActive(true);
        }
        audiosource.clip =ImpactSound;
        audiosource.Play();
    }
    void LeftAttackColliderClose()
    {
        foreach(GameObject obj in SideTrig)
        {
            obj.SetActive(false);
        }
        if(RightGate.GetComponent<BossDoor>().Ent == true)
        {
            RightGate.GetComponent<BossDoor>().Ent = false;
            RightGate.GetComponent<AudioSource>().Play();
        }
        ActiveChange();
    }
    void ShootAttackActive()
    {
        Rigidbody shoot = Instantiate(ShootProjectile, shootpoint.transform.position, Quaternion.identity);
        shoot.velocity = shootpoint.transform.forward*ShootSpeed;
        //Physics.IgnoreCollision(transform.GetComponent<Collider>(), shoot.GetComponent<Collider>());
    }
    void ShootAttackClose()
    {
        ActiveChange();
    }
    
    void ThreeLocationMove()
    {
        if((Local == 1 && Action == 3 && transform.position == RightPoint.transform.position) || //從右撞
        (Local == 2 && Action == 4 && transform.position == LeftPoint.transform.position) )//從左撞
        {
            ImpactCheck=true;
        }

        if((Local == 1 && Action == 3 && transform.position == RightImpactPoint.transform.position) || //從右撞
        (Local == 2 && Action == 4 && transform.position == LeftImpactPoint.transform.position) ||//從左撞
        (Local == 1 && Action != 3 && transform.position == RightPoint.transform.position) ||//右邊前衝射擊
        (Local == 2 && Action != 4 && transform.position == LeftPoint.transform.position) || //左邊前衝射擊
        (Local == 3 && transform.position == MiddlePoint.transform.position))//中間前衝射擊
        {
            ImpactCheck=false;
            animator.SetInteger("Action",Action);
            //Action =0;
        }
        else if(Local == 1 && Action == 3 && ImpactCheck)
        {
            transform.position = Vector3.MoveTowards(transform.position, RightImpactPoint.transform.position, Speed * Time.deltaTime);
            if(LeftGate.GetComponent<BossDoor>().Ent == false)
            {
                LeftGate.GetComponent<BossDoor>().Ent = true;
                LeftGate.GetComponent<AudioSource>().Play();
            }
        }
        else if(Local == 2 && Action == 4 && ImpactCheck)
        {
            transform.position = Vector3.MoveTowards(transform.position, LeftImpactPoint.transform.position, Speed * Time.deltaTime);
            if(RightGate.GetComponent<BossDoor>().Ent == false)
            {
                RightGate.GetComponent<BossDoor>().Ent = true;
                RightGate.GetComponent<AudioSource>().Play();
            }
        }
        else if(Local == 1 )
        {
            transform.position = Vector3.MoveTowards(transform.position, RightPoint.transform.position, Speed * Time.deltaTime);
        }
        else if(Local == 2 )
        {
            transform.position = Vector3.MoveTowards(transform.position, LeftPoint.transform.position, Speed * Time.deltaTime);
        }
        else if(Local == 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, MiddlePoint.transform.position, Speed * Time.deltaTime);
        }
    }
}
