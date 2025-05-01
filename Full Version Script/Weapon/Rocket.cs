using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject explosion;
    private float BOMBTime = 6f;
    private float Timer = 0f;
    public GameObject RocketRange;
    public MeshRenderer mesh;
    private WeaponSwitcher WS;
    private bool particle = false;

    private AudioSource audiosource;
    public AudioClip ExpositionSound;
    void Start()
    {
        WS = GameObject.Find("WeaponSwitch").GetComponent<WeaponSwitcher>();
        Timer = 0f;
        RocketRange.SetActive(false);
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Excution();
        
        if (Timer>=BOMBTime && particle == false)
        {
            particle = true;

            GetComponent<Rigidbody>().velocity = Vector3.zero;
            mesh.enabled =false; 

            RocketRange.SetActive(true);
            var expFx = Instantiate (explosion, transform.position, transform.rotation);
            audiosource.clip = ExpositionSound;
            audiosource.Play();
            Destroy(expFx, 1);
            Destroy(gameObject,1);
        }
        Timer+=Time.deltaTime;
    }
    void OnCollisionEnter(Collision collision) 
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        mesh.enabled =false;

        RocketRange.SetActive(true);
        var expFx = Instantiate (explosion, transform.position, transform.rotation);
        audiosource.clip = ExpositionSound;
        audiosource.Play();
        Destroy(expFx, 1);
        Destroy(gameObject,1);
    }
    private void Excution()
    {
        if (Input.GetMouseButtonDown (1) && WS.RocketExplosion == true)
        {
            Timer = BOMBTime;
        }
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "BuffMachineFlame")
        {
            Destroy(gameObject);
        }
    }

}
