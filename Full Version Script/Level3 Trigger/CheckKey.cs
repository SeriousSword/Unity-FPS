using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckKey : MonoBehaviour
{
    public GameObject gateR;
    public GameObject gateL;
    public GameObject KeyIcon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBody" && KeyIcon.activeSelf)
        {
            gateL.GetComponent<OpenGate>().enabled=true;
            gateR.GetComponent<OpenGate>().enabled=true;
        }
    }
}
