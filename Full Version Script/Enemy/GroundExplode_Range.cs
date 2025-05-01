using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundExplode_Range : MonoBehaviour
{
    public GameObject GroundExplode;
    private GroundExplode_AI GE;
    void Start()
    {
        GE = GroundExplode.GetComponent<GroundExplode_AI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag =="PlayerBody")
        {
            GE.RangeLock = true;
        }
    }
    void OnTriggerExit(Collider other) 
    {
        if(other.tag =="PlayerBody")
        {
            GE.RangeLock = false;
        }
    }
}
