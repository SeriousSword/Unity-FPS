using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpTrigger : MonoBehaviour
{
    public GameObject q;
    void Start()
    {
        q.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerBody")
        {
            q.SetActive(true);
        }
        
    }
}
