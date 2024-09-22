using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuffMachine_Attack : MonoBehaviour
{
    private Animator animator;
    public GameObject Fire;
    public GameObject Parent;
    private GameObject player;
    public GameObject FirePoint;
    private HelathAndArmor HAA;
    private float BuffTime = 15f;
    private float NowTime = 15f;
    public GameObject BuffUI;
    public GameObject Number;
    private TextMeshProUGUI t;
    private AudioSource audiosource;
    public AudioClip DeathSound;
    public AudioClip FireSound;
    public AudioClip PowerSound;
    public AudioClip DoubleSound;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerBody");
        HAA = player.GetComponent<HelathAndArmor>();
        NowTime = 15f;
        BuffTime = 15f;
        BuffUI.SetActive(false);
        t = Number.GetComponent<TextMeshProUGUI>();
        animator = gameObject.GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(NowTime >= BuffTime)
        {
            HAA.DamageRise = false;
            BuffUI.SetActive(false);
        }
        else if(NowTime < BuffTime)
        {
            NowTime +=Time.deltaTime;
        }
        text();
    }
    
    public void Buff()
    {
        audiosource.clip = PowerSound;
        audiosource.Play();
        NowTime = 0f;
        HAA.DamageRise = true;
        BuffUI.SetActive(true);
        animator.SetInteger("Action",2);
        animator.SetBool("Ready",false);
    }
    public void FireWall()
    {
        audiosource.clip = FireSound;
        audiosource.Play();
        Instantiate(Fire, FirePoint.transform.position, Quaternion.identity);
        animator.SetInteger("Action",1);
        animator.SetBool("Ready",false);
    }
    public void DoublePower()
    {
        audiosource.clip = DoubleSound;
        audiosource.Play();
        NowTime = 0f;
        HAA.DamageRise = true;
        BuffUI.SetActive(true);
        Instantiate(Fire, FirePoint.transform.position, Quaternion.identity);
        animator.SetInteger("Action",0);
        animator.SetBool("Ready",false);
    }
    public void Death()
    {
        audiosource.clip = DeathSound;
        audiosource.Play();
        HAA.DamageRise = false;
        Destroy(Parent,3);
    }
    void text()
    {
        int TimeText =15-(int)NowTime;
        string Textstring = TimeText.ToString();
        t.text =Textstring + " s";
    }
}
