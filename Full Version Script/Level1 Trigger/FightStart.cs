using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightStart : MonoBehaviour
{
    public GameObject Player;
    public GameObject UI;
    public GameObject StartFight;
    private KeyCode UseKey = KeyCode.E;
    private bool Ent = false;

    void Start()
    {
        UI.SetActive(false);
        StartFight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Ent == true && Input.GetKeyDown(UseKey))
        {
            StartFight.SetActive(true);
            gameObject.SetActive(false);
        }
        
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag =="PlayerBody")
        {
            Ent = true;
            UI.SetActive(true);
        }
        
    }
    
    void OnTriggerExit(Collider other) 
    {
        UI.SetActive(false);
        Ent = false;
    }
}
