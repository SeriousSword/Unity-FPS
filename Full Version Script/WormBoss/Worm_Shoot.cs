using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm_Shoot : MonoBehaviour
{
    private float DeathTime =5f;
    private float CountTime =0f;
    private AudioSource audiosource;
    public AudioClip MoveSound;
    public AudioClip HitSound;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = MoveSound;
        audiosource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(CountTime <DeathTime)
        {
            CountTime+=Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        audiosource.clip = HitSound;
        audiosource.Play();
        Destroy(gameObject,1);
    }
}
