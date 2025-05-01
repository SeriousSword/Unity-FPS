using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float T =0f;
    public GameObject next;

    void Start()
    {
        next.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        T +=Time.deltaTime;
        
        if(T>=25f)
        {
            next.SetActive(true);
            this.enabled = false;
        }
    }
}
