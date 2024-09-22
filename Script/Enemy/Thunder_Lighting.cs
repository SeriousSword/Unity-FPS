using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Thunder_Lighting : MonoBehaviour
{
    float moveSpeed = 8f;
    float DelateTime = 5f;
    float time = 0f;
    bool Hit = false;
    private Transform player;
    private Rigidbody rb;
    private Vector3 pp;
    private Vector3 tp;
    private Vector3 direction;
    private AudioSource audiosource;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerBody").transform;
        pp = player.position;
        tp = transform.position;
        direction = (pp-tp).normalized;
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        FacePlayer();
        time+=Time.deltaTime;
        if(Hit ==false)
        {
            MoveTowardsTarget();
        }
        else if (time>=DelateTime)
        {
            Hit = true;
            Destroy(gameObject);
        }
    }
    void MoveTowardsTarget()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag== "player" && other.tag == "Default")
        {
            Hit = true;
            Destroy(gameObject);
        }
        
    }
    void FacePlayer()
    {
        Vector3 directionToFace = player.position - transform.position;
        directionToFace.y = 0; // 保持敌人在y轴上不旋转
        Quaternion targetRotation = Quaternion.LookRotation(directionToFace);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
    }
}
