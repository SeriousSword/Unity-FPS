using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellAmmo : MonoBehaviour
{
    private WeaponSwitcher WS;
    void Start()
    {
        WS=GameObject.Find("WeaponSwitch").GetComponent<WeaponSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        if(WS.ShotgunAmmo>=WS.ShotgunAmmoLimit)
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
