using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllSupport : MonoBehaviour
{
    private WeaponSwitcher WS;
    private HelathAndArmor HAA;
    void Start()
    {
        WS=GameObject.Find("WeaponSwitch").GetComponent<WeaponSwitcher>();
        HAA = GameObject.Find("PlayerBody").GetComponent<HelathAndArmor>();
    }

    void Update()
    {
        if(WS.SMGAmmo<WS.SMGAmmoLimit || WS.ShotgunAmmo<WS.ShotgunAmmoLimit || WS.FlameThrowerAmmo<WS.FlameThrowerAmmoLimit 
        || WS.MinigunAmmo<WS.MinigunAmmoLimit || WS.RocketLauncherAmmo<WS.RocketLauncherAmmoLimit || HAA.Armor<200 || HAA.Health<200)
        {
            GetComponent<Collider>().enabled = true;
        }
        else
        {
            
            GetComponent<Collider>().enabled = false;
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
