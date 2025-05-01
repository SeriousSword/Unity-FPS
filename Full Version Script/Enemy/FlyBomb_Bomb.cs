using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBomb_Bomb : MonoBehaviour
{
    public GameObject explosion;
    public GameObject Fire;
    public GameObject BombRange;
    public MeshRenderer mesh;
    private AudioSource audiosource;
    public AudioClip ExpositionSound;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision) 
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        mesh.enabled =false;

        BombRange.SetActive(true);
        var expFx = Instantiate (explosion, transform.position, transform.rotation);
        audiosource.clip = ExpositionSound;
        audiosource.Play();
        Destroy(expFx, 1);
        Destroy(gameObject,1);
    }
}
