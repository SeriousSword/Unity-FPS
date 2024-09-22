using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RocketLauncherPoint : MonoBehaviour
{
    private WeaponSwitcher WS;
    float RocketLauncherAmmo;
    public TextMeshProUGUI t;
    void Start()
    {
        WS = GameObject.Find("WeaponSwitch").GetComponent<WeaponSwitcher>();
        RocketLauncherAmmo = WS.RocketLauncherAmmo;
    }

    void Update()
    {
        RocketLauncherAmmo = WS.RocketLauncherAmmo;
        string RocketLauncherAmmoString = RocketLauncherAmmo.ToString();
        t.text = RocketLauncherAmmoString;
    }
}
