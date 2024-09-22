using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DashCoolDown : MonoBehaviour
{
    public UnityEngine.UI.Image Icon;
    private float Energy,MaxEnergy;
    //public GameObject DashC;
    private PlayerMove PM;
    void Start()
    {
        PM = GameObject.Find("PlayerBody").GetComponent<PlayerMove>();
        MaxEnergy = PM.DashCoolDownTime + PM.DashTime;
    }

    // Update is called once per frame
    void Update()
    {
        Iconfiller();
    }

    private void Iconfiller()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && PM.DashAllow == true)
        {
            Energy = 0;
        }
        if (Energy<MaxEnergy)
        {
            Energy += Time.deltaTime;
        }
        Icon.fillAmount = Energy/MaxEnergy;
    }
}
