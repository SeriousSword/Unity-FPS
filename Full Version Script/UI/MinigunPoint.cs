using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinigunPoint : MonoBehaviour
{
    private WeaponSwitcher WS;
    float MinigunAmmo;
    public TextMeshProUGUI t;
    void Start()
    {
        WS = GameObject.Find("WeaponSwitch").GetComponent<WeaponSwitcher>();
        MinigunAmmo = WS.MinigunAmmo;
    }

    void Update()
    {
        MinigunAmmo = WS.MinigunAmmo;
        string MinigunAmmoString = MinigunAmmo.ToString();
        t.text = MinigunAmmoString;
    }
}
