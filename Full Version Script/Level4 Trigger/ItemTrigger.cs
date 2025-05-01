using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    public GameObject Item;
    public GameObject Trigger;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentsInChildren<Transform>(true).Length <= 1)
        {
            if(Item!=null)
            {
                Item.SetActive(true);
            }
            if(Trigger!=null)
            {
                Trigger.SetActive(true);
            }
        }
    }
}
