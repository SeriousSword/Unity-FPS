using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalHPItem : MonoBehaviour
{
    private HelathAndArmor HAA;
    public float limit;
    public GameObject Trig;
    void Start()
    {
        HAA = GameObject.Find("PlayerBody").GetComponent<HelathAndArmor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HAA.Health>=limit)
        {
            Trig.SetActive(false);
        }
        else
        {
            Trig.SetActive(true);
        }
    }
    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "PlayerBody" )
        {
            Destroy(gameObject);
        }
    }
}
