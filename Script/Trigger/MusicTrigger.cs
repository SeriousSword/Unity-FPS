using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour

{
    private AudioSource audiosource;
    public AudioClip NormalMusic;



    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = NormalMusic;
        audiosource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
