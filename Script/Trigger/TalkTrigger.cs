using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkTrigger : MonoBehaviour
{
    public GameObject talker;
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    public GameObject Exp;
    public GameObject dust;
    public GameObject FinalWave;
    public Collider self;
    void Start()
    {
        Exp.SetActive(false);
        dust.SetActive(false);
    }
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBody")
        {
            self.enabled=false;
            talker.SetActive(true);
            Exp.SetActive(true);
            wall1.SetActive(false);
            wall2.SetActive(false);
            wall3.SetActive(false);
            dust.SetActive(true);
            FinalWave.SetActive(true);
            Destroy(Exp,0.5f);
            Destroy(talker,2f);
        }
    }

}
