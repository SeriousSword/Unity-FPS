using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    public Vector3 targetPosition;
    public float zMove;
    public float moveSpeed; 

    void Start()
    {
        targetPosition = transform.position + new Vector3(0, 0, zMove); 
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
