using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private GateMove GMR;
    private GateMove GML;
    public GameObject RightGate;
    public GameObject LeftGate;
    private bool OP=false;
    void Start()
    {
        GMR = RightGate.GetComponent<GateMove>();
        GML = LeftGate.GetComponent<GateMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentsInChildren<Transform>(true).Length <= 1)
        {
            if(OP==false)
            {
                OP=true;
                GMR.Ent = true;
                GML.Ent = true;
            }
            
        }/*
        if(LeftGate.GetComponent<BossDoor>().Ent == true)
        {
            LeftGate.GetComponent<BossDoor>().Ent = false;
            LeftGate.GetComponent<AudioSource>().Play();
        }*/
        
    }
}
