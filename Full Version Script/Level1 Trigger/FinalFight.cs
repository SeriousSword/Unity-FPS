using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalFight : MonoBehaviour
{
    public GameObject wave1;
    public GameObject wave2;
    public GameObject wave3;
    public float Wave2Time;
    public float Wave3Time;
    public float ChangeTime;
    private float Timer;
    public bool fight = true;
    public GameObject Germ;
    public GameObject Supplie;
    void Start()
    {
        Timer = 0f;
        wave2.SetActive(false);
        wave3.SetActive(false);
        Germ.SetActive(true);
        Supplie.SetActive(false);
    }

    void Update()
    {
        
        if(fight == true)
        {
            Timer+=Time.deltaTime;
            if(Timer>=Wave3Time)
            {
                if(wave3)
                {
                    wave3.SetActive(true);
                }
                fight = false;
                Timer = 0f;
            }
            else if (Timer>=Wave2Time && wave2)
            {
                wave2.SetActive(true);
            }
            else if(Timer>=3f && Germ)
            {
                Germ.SetActive(false);
            }
        }
        else if (GetComponentsInChildren<Transform>(true).Length <= 1)
        {
            SceneManager.LoadSceneAsync(0);
            Timer+=Time.deltaTime;
            if (Timer >=ChangeTime)
            {
                
            }
        }
        
    }
}
