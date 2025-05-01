using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour
{
    private Vector3 OriginPosition;
    private Vector3 targetPosition;
    public float xMove;
    public bool Ent =false;
    private float Speed = 10f;
    private AudioSource audiosourse;
    void Start()
    {
        OriginPosition =transform.position;
        targetPosition =transform.position + new Vector3(xMove, 0, 0);
        audiosourse = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Ent == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, OriginPosition, Speed * Time.deltaTime);
        }
    }
}
