using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    // Start is called before the first frame update
    private WeaponSwitcher WS;
    void Start()
    {
        WS=GameObject.Find("WeaponSwitch").GetComponent<WeaponSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        if(WS.FlameThrowerAmmo>=WS.FlameThrowerAmmoLimit)
        {
            GetComponent<Collider>().enabled = false;
        }
        else
        {
            GetComponent<Collider>().enabled = true;
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
