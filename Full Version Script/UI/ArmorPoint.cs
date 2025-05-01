using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArmorPoint : MonoBehaviour
{
    
    private HelathAndArmor HAA;
    float Armor;
    public TextMeshProUGUI t;
    void Start()
    {
        HAA = GameObject.Find("PlayerBody").GetComponent<HelathAndArmor>();
        Armor = HAA.Armor;
    }

    // Update is called once per frame
    void Update()
    {
        Armor = HAA.Armor;
        string ArmorString = Armor.ToString();
        t.text = ArmorString;
    }
}
