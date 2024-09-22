using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffMachine_Flame : MonoBehaviour
{
    private float t = 15f;
    private float n = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        n+=Time.deltaTime;
        if(n>=t)
        {
            Destroy(gameObject);
        }
    }
}
