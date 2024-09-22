using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SMGPoint : MonoBehaviour
{
    private WeaponSwitcher WS;
    float SMGAmmo;
    public TextMeshProUGUI t;
    void Start()
    {
        WS = GameObject.Find("WeaponSwitch").GetComponent<WeaponSwitcher>();
        SMGAmmo = WS.SMGAmmo;
    }

    void Update()
    {
        SMGAmmo = WS.SMGAmmo;
        string SMGAmmoString = SMGAmmo.ToString();
        t.text = SMGAmmoString;
    }
}
