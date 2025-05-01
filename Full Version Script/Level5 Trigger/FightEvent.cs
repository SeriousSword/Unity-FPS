using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightEvent : MonoBehaviour
{
    public GameObject Houses;
    public GameObject Enemy;
    public GameObject Wall1;
    public GameObject Wall2;
    void Start()
    {
        Wall1.SetActive(false);
        Wall2.SetActive(false);
        Enemy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "PlayerBody")
        {
            Wall1.SetActive(true);
            Wall2.SetActive(true);
            Houses.GetComponent<HouseMove>().HouseDown();
            Destroy(gameObject,1);
        }
        
    }
}
