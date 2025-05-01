using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigLight_Range : MonoBehaviour
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
            BL.RangeLock = true;
        }
    }
    void OnTriggerExit(Collider other) 
    {
        if(other.tag =="PlayerBody")
        {
            BL.RangeLock = false;
        }
    }
}
