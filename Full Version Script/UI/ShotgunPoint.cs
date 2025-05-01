using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShotgunPoint : MonoBehaviour
{
    private WeaponSwitcher WS;
    float ShotgunAmmo;
    public TextMeshProUGUI t;
    void Start()
    {
        WS = GameObject.Find("WeaponSwitch").GetComponent<WeaponSwitcher>();
        ShotgunAmmo = WS.ShotgunAmmo;
    }

    void Update()
    {
        ShotgunAmmo = WS.ShotgunAmmo;
        string ShotgunAmmoString = ShotgunAmmo.ToString();
        t.text = ShotgunAmmoString;
    }
}
