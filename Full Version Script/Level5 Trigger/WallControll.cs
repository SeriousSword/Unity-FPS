using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControll : MonoBehaviour
{
    public GameObject Wall1;
    public GameObject Wall2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentsInChildren<Transform>(true).Length <= 1)
        {
            Wall1.SetActive(false);
            Wall2.SetActive(false);
            this.enabled = false;
        }
    }
}
