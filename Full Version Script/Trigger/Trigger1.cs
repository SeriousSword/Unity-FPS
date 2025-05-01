using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger1 : MonoBehaviour
{
    public GameObject Wave;
    public GameObject Warning;
    void Start()
    {
        Wave.SetActive(false);
        Warning.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBody")
        {
            Wave.SetActive(true);
            Warning.SetActive(true);
            Destroy(gameObject);
        }
    }
}
