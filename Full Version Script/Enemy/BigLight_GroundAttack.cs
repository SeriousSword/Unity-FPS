using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BigLight_GroundAttack : MonoBehaviour
{
    private AudioSource audiosource;
    public AudioClip DownSound;
    public LayerMask targetLayer;
    public GameObject BigLight;
    private BigLight_Attack BLA;
    private Collider CO;
    public GameObject HitParticle;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        BLA = BigLight.GetComponent<BigLight_Attack>();
        CO = gameObject.GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) 
    {
        if (((1 << other.gameObject.layer) & targetLayer) != 0)
        {
            CO.enabled =false;
            audiosource.clip = DownSound;
            audiosource.Play();
            var lauFx = Instantiate(HitParticle, gameObject.transform.position, Quaternion.identity);
            Destroy(lauFx,1);
        }
    }
}
