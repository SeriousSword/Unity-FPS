using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject KeyIcon;
    public GameObject KeyObject;
    void Start()
    {
        KeyIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "PlayerBody")
        {
            KeyIcon.SetActive(true);
            KeyObject.SetActive(false);
        }
    }
}
