using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Start : MonoBehaviour
{
    public GameObject Friend;
    public GameObject Enemy;
    void Start()
    {
        Enemy.SetActive(false);
        Friend.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) 
    {
        if (other.tag=="PlayerBody")
        {
            Enemy.SetActive(true);
            Friend.SetActive(true);
            Destroy(gameObject,1);
        }
    }
}
