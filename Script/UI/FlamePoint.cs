using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlamePoint : MonoBehaviour
{
    private WeaponSwitcher WS;
    float FlameThrowerAmmo;
    public TextMeshProUGUI t;
    void Start()
    {
        WS = GameObject.Find("WeaponSwitch").GetComponent<WeaponSwitcher>();
        FlameThrowerAmmo = WS.FlameThrowerAmmo;
    }

    void Update()
    {
        FlameThrowerAmmo = WS.FlameThrowerAmmo;
        string FlameThrowerAmmoString = FlameThrowerAmmo.ToString();
        t.text = FlameThrowerAmmoString;
    }
}
