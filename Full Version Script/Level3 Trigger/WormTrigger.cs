using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormTrigger : MonoBehaviour
{
    public GameObject[] WakeObject;
    public GameObject BreakObject;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.tag =="PlayerBody")
        {
            foreach (GameObject obj in WakeObject)
            {
                if (obj!=null)
                obj.SetActive(true);
            }
            BreakObject.SetActive(false);
            gameObject.SetActive(false);
        }
        
    }
}
