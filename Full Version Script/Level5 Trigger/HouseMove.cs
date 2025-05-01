using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseMove : MonoBehaviour
{
    public Vector3 targetPosition;
    private float yMove = 30;
    private float moveSpeed =10f;
    public GameObject Enemy;
    public GameObject Dust;
    private float T=0f;
    void Start()
    {
        moveSpeed = 10f;
        targetPosition = transform.position;
        Enemy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if (targetPosition != transform.position)
        {
            Dust.SetActive(true);
        }
        else
        {
            Dust.SetActive(false);
        }
    }
    public void HouseDown()
    {
        targetPosition = transform.position + new Vector3(0, -yMove, 0);
        Invoke("WakeEnemy", 5f);
    }
    void WakeEnemy()
    {
        Enemy.SetActive(true);
    }
}
