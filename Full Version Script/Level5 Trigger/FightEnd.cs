using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightEnd : MonoBehaviour
{
    public GameObject Boss;
    public GameObject BossCover;
    public bool Element = false;
    void Start()
    {
        Element = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentsInChildren<Transform>(true).Length <= 1)
        {
            Element = true;

        }
    }
}
