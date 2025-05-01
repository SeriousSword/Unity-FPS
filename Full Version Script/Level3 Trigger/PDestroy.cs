using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDestroy : MonoBehaviour
{
    private float T= 0f;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        T+=Time.deltaTime;
        if( T>=1f)
        {
            Destroy(gameObject);
        }
    }
}
