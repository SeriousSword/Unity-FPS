using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : Shoot
{
    public Animator animator;
    public GameObject PB;
    private PlayerMove PM;
    public GameObject WS;
    private WeaponSwitcher WSS;
    private AudioSource audiosource;
    public AudioClip ShootSound;
    public AudioClip PrepareSound;
    public Rigidbody Bullet;
    private float ShootRate = 1/12f;
    private float ShootTimer = 0f;
    public GameObject shootpoint;
    public ParticleSystem GunfireM;
    float speed = 100f;
    public RectTransform CrossCenter;
    public Camera PlayerCamera;
    void Start()
    {
        PM = PB.GetComponent<PlayerMove>();
        WSS =WS.GetComponent<WeaponSwitcher>();
        audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (ShootTimer<ShootRate)
        {
            ShootTimer += Time.deltaTime;
        }
        float x = PM.x;//input水平
        float z = PM.z;//input垂直
        /*
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("PrePare"))
        {
            audiosource.clip = PrepareSound;
            audiosource.Play();
        }
        else if  (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            audiosource.clip = ShootSound;
            audiosource.Play();
        }
        else 
        {
            audiosource.Stop();
        }*/
        if(WSS.MinigunAmmo>=1)
        {
            MainFire();
            AltFire();
        }
        
        
        if (x != 0f || z != 0f)
        {
            animator.SetBool("Moving",true);
        }
        else
        {
            animator.SetBool("Moving",false);
        }
    }

    public override void MainFire()
    {
        Vector2 ScreenPoint = RectTransformUtility.WorldToScreenPoint(null, CrossCenter.position);
        Vector3 ViewportPoint = PlayerCamera.ScreenToViewportPoint(ScreenPoint);
        Ray ray = PlayerCamera.ViewportPointToRay(ViewportPoint);
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && ShootTimer>=ShootRate)
        {
            ShootTimer = 0;
            if(audiosource.clip != ShootSound)
            {
                GunfireM.Play();
                audiosource.clip = ShootSound;
                audiosource.Play();
            }
            RaycastHit hit;
            Vector3 targetPoint;
            if (Physics.Raycast(ray, out hit))
            {
                targetPoint = hit.point;
            }
            else
            {
                targetPoint = ray.GetPoint(300); // 如果没有碰撞，目标点设为射线的远点
            }
            Vector3 direction = (targetPoint - shootpoint.transform.position).normalized;
            WSS.MinigunAmmo-=1;
            Rigidbody shoot = Instantiate(Bullet, shootpoint.transform.position, Quaternion.LookRotation(direction));  	
		    shoot.velocity = transform.TransformDirection(new Vector3( speed, 0, 0));
		    Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), shoot.GetComponent<Collider>());
        }

        if (Input.GetMouseButtonDown (0))
        {
            animator.SetBool("Fire",true);
            animator.SetBool("Prepare",true);
            audiosource.clip = PrepareSound;
            audiosource.Play();
        }
        else if (Input.GetMouseButtonUp (0) ||WSS.MinigunAmmo<=0)
        {
            animator.SetBool("Fire",false);
            animator.Play("Prepare",-1,0f);
            animator.SetBool("Prepare",false);
            GunfireM.Stop();
            audiosource.Stop();
        }
    }
    public override void AltFire()
    {
        if (Input.GetMouseButtonDown (1))
        {
            animator.SetBool("Prepare",true);
            audiosource.clip = PrepareSound;
            audiosource.Play();
        }
        else if (Input.GetMouseButtonUp (1))
        {
            animator.SetBool("Prepare",false);
            audiosource.Stop();
        }
    }
}
