using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthPoint : MonoBehaviour
{
    private HelathAndArmor HAA;
    float Health;
    public TextMeshProUGUI t;
    void Start()
    {
        HAA = GameObject.Find("PlayerBody").GetComponent<HelathAndArmor>();
        Health = HAA.Health;
    }

    void Update()
    {
        Health = HAA.Health;
        string HealthString = Health.ToString();
        t.text = HealthString;
    }
}
