using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorReverse : MonoBehaviour
{
    private GateMove GMR;
    private GateMove GML;
    public GameObject RightGate;
    public GameObject LeftGate;
    private bool Triggered = false;
    void Start()
    {
        GMR = RightGate.GetComponent<GateMove>();
        GML = LeftGate.GetComponent<GateMove>();
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag =="PlayerBody")
        {
            GMR.Ent = false;
            GML.Ent = false;
        }
    }
    private void OnTriggerStay(Collider other) 
    {
        if (other.tag =="PlayerBody")
        {
            GMR.Ent = false;
            GML.Ent = false;
        }
    }
}
