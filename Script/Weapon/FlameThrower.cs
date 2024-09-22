using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlameThrower : Shoot
{
    public Animator animator;

    //[Tooltip("射線射程")]private float range;
    //[Tooltip("射線射速")]private float rate;
    public ParticleSystem Flame;
    public GameObject FlameRange;
    public GameObject PB;
    private PlayerMove PM;
    public GameObject WS;
    private WeaponSwitcher WSS;
    private AudioSource audiosource;
    public AudioClip ThrowSound;
    private float AmmoTime =0.1f;
    private float count=0;
    private void Start() 
    {
        //Flame = GetComponent<ParticleSystem>();
        //rate = 0.05f;
        //range = 100f;
        FlameRange.SetActive(false);
        PM = PB.GetComponent<PlayerMove>();
        WSS =WS.GetComponent<WeaponSwitcher>();
        audiosource = GetComponent<AudioSource>();
        audiosource.Stop();
    }
    private void Update() 
    {
        float x = PM.x;//input水平
        float z = PM.z;//input垂直
        if(count<AmmoTime)
        {
            count +=Time.deltaTime;
        }
        if(WSS.FlameThrowerAmmo<=0)
        {
            Flame.Stop();
            audiosource.Stop();
            FlameRange.SetActive(false);
            animator.SetBool("Fire",false);
        }
        if (Input.GetMouseButton (0) &&WSS.FlameThrowerAmmo>=1)
        {
            MainFire();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Flame.Stop();
            audiosource.Stop();
            FlameRange.SetActive(false);
            animator.SetBool("Fire",false);
        }

        if (x != 0f || z != 0f)
        {
            animator.SetBool("Moving",true);
        }
        else
        {
            animator.SetBool("Moving",false);
        }

        /*
        if (FireTimer<=rate)
        {
            FireTimer += Time.deltaTime;
        }
        */
    }
    
    public override void MainFire()
    {   

        if(count>=AmmoTime)
        {
            WSS.FlameThrowerAmmo-=1;
            count =0;
        }
        if (Input.GetMouseButtonDown (0))
        {
            Flame.Play();
            audiosource.clip = ThrowSound;
            audiosource.Play();
            FlameRange.SetActive(true);
            animator.SetBool("Fire",true);
        }
        
        /*
        if (FireTimer<=rate)
        {
            
            return;
        }

        
        
        RaycastHit hit;
        Vector3 shootDirection = ShootPoint.forward;
        shootDirection = shootDirection+ ShootPoint.TransformDirection(new Vector3(Random.Range(-SpreadFactor,SpreadFactor),Random.Range(-SpreadFactor,SpreadFactor)));
        if (Physics.Raycast(ShootPoint.position,shootDirection,out hit,range))
        {
            Debug.Log(hit.transform.gameObject.name+"Hit");
        }
        FireTimer = 0f;
        */

    }
    public override void AltFire()
    {
        
    }

    

}
