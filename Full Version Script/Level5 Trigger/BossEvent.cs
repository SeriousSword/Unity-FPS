using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEvent : MonoBehaviour
{
    public bool Fire = false ;
    public bool Water = false ;
    public bool Air = false ;
    public bool Earth = false ;
    public GameObject FireLock ;
    public GameObject WaterLock ;
    public GameObject AirLock ;
    public GameObject EarthLock ;

    public GameObject Boss;
    public GameObject BossCover;
    public GameObject BossUI;
    
    void Start()
    {
        Fire = false ;
        Water = false ;
        Air = false ;
        Earth = false ;
        Boss.GetComponent<FinalBoss_AI>().enabled = false;
        BossUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Fire = FireLock.GetComponent<FightEnd>().Element;
        Water = WaterLock.GetComponent<FightEnd>().Element;
        Air = AirLock.GetComponent<FightEnd>().Element;
        Earth = EarthLock.GetComponent<FightEnd>().Element;
        if (Fire == true && Water == true && Air == true && Earth == true)
        {
            StartCoroutine(BossWakeup());
        }
    }
    IEnumerator BossWakeup()
    {
        
        /*Player.transform.position = new Vector3(-19.03811f,1.8f,-3.664407f);
        Player.transform.position = new Vector3(0f,0f,0f);
        PlayerCamera.transform.position = new Vector3(-37.937f,0f,0f);*/
        yield return new WaitForSeconds(2f);
        Boss.GetComponent<FinalBoss_AI>().enabled = true;
        BossUI.SetActive(true);
        BossCover.SetActive(false);
    }
}

