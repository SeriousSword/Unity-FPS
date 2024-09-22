using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    public GameObject NPC;
    void Start()
    {
        NPC.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentsInChildren<Transform>(true).Length <= 1)
        {
            NPC.SetActive(true);
        }
    }
}
