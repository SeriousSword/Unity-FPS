using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigLight_Light : MonoBehaviour
{
    public GameObject BigLight;
    private BigLight_AI BL;
    void Start()
    {
        BL = BigLight.GetComponent<BigLight_AI>();
    }
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag =="PlayerBody")
        {
            BL.LightLock = true;
        }
    }
    void OnTriggerExit(Collider other) 
    {
        if(other.tag =="PlayerBody")
        {
            BL.LightLock = false;
        }
    }
}
