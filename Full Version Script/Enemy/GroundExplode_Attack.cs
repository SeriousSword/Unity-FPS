using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundExplode_Attack : MonoBehaviour
{
    public GameObject Explode;
    public GameObject Parent;
    public Animator animator;
    private Transform player; 
    public LayerMask groundLayer; 
    private Rigidbody rb;
    private float moveSpeed = 15;
    private AudioSource audiosource;
    public AudioClip StepSound;
    public AudioClip JumpSound;
    public AudioClip DeathSound;
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("PlayerBody").transform;
        rb = Parent.GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attack()
    {
        
        Vector3 PlayerPosition = player.position;
        RaycastHit hit;
        
        if (Physics.Raycast(PlayerPosition, Vector3.down, out hit, Mathf.Infinity, groundLayer))
        {
            Vector3 SpawnPosition = hit.point;
            Instantiate(Explode, SpawnPosition, Quaternion.identity*Quaternion.Euler(90,0,0));
        }
        audiosource.clip =StepSound;
        audiosource.Play();
        animator.SetInteger("Action",0);
    }
    public void Death()
    {
        audiosource.clip =DeathSound;
        audiosource.Play();
        Destroy(Parent,3);
    }
    public void JumpStart()
    {
        audiosource.clip =JumpSound;
        audiosource.Play();
        Vector3 direction = new Vector3 (player.position.x - Parent.transform.position.x, 0f, player.position.z - Parent.transform.position.z).normalized;
        rb.velocity = direction * moveSpeed;
    }
    public void JumpEnd()
    {
        rb.velocity =new Vector3(0,0,0);
        animator.SetInteger("Action",0);
    }
    
}
