using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassTrigger : MonoBehaviour
{
    public GameObject Warning;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentsInChildren<Transform>(true).Length <= 1)
        {
            Warning.SetActive(false);
            Destroy(Warning);
            Destroy(gameObject);
        }
    }
}
