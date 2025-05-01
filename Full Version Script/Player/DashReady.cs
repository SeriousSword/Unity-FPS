using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class DashReady : MonoBehaviour
{
    bool DashIconAllow;
    public GameObject DashR;
    private PlayerMove PM;
    void Start()
    {
        PM = GameObject.Find("PlayerBody").GetComponent<PlayerMove>();
    }
    void Update()
    {
        
        DashIconAllow = PM.DashAllow;
        if (DashIconAllow == true)
        {
            DashR.SetActive(true);
        }
        else
        {
            DashR.SetActive(false);
        }
    }
}
