using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSmoke_Jump : MonoBehaviour
{
    private AudioSource audiosource;
    public AudioClip DownSound;
    public LayerMask targetLayer;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) 
    {
        if (((1 << other.gameObject.layer) & targetLayer) != 0)
        {
            audiosource.clip = DownSound;
            audiosource.Play();
        }
    }
}
