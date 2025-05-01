using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RocketLauncher : Shoot
{
    public Animator animator;
    public GameObject PB;
    private PlayerMove PM;
    public GameObject WS;
    private WeaponSwitcher WSS;
    public Rigidbody Rocket;//砲彈
    private float LaunchRate = 5/6f;
    private float LaunchTimer = 0f;
	float speed = 20;//砲彈的飛行速度
    private AudioSource audiosource;
    public AudioClip LaunchSound;
    public GameObject LaunchParticle;
    public GameObject LaunchPoint;
    public RectTransform CrossCenter;
    public Camera PlayerCamera;
    //private Vector3 RO = new Vector3(90,0,0);
    
    void Start()
    {
        PM = PB.GetComponent<PlayerMove>();
        WSS =WS.GetComponent<WeaponSwitcher>();
        LaunchTimer = LaunchRate;
        audiosource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (LaunchTimer<LaunchRate)
        {
            LaunchTimer += Time.deltaTime;
        }
        float x = PM.x;//input水平
        float z = PM.z;//input垂直
        if(WSS.RocketLauncherAmmo <=0)
        {
            animator.SetBool("Fire",false);
        }
        if (Input.GetMouseButton (0) &&WSS.RocketLauncherAmmo >=1)
        {
            MainFire();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("Fire",false);
        }
        if (Input.GetMouseButton (1))
        {
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
        if (LaunchTimer>=LaunchRate)
        {
            //shootpoint
            Vector2 ScreenPoint = RectTransformUtility.WorldToScreenPoint(null, CrossCenter.position);
            Vector3 ViewportPoint = PlayerCamera.ScreenToViewportPoint(ScreenPoint);
            Ray ray = PlayerCamera.ViewportPointToRay(ViewportPoint);

            animator.SetBool("Fire",true); 
            var lauFx = Instantiate (LaunchParticle, LaunchPoint.transform.position, LaunchPoint.transform.rotation);
            audiosource.clip = LaunchSound;
            audiosource.Play();
            RaycastHit hit;
            Vector3 targetPoint;
            if (Physics.Raycast(ray, out hit))
            {
                targetPoint = hit.point;
            }
            else
            {
                targetPoint = ray.GetPoint(120); // 如果没有碰撞，目标点设为射线的远点
            }
            Vector3 direction = (targetPoint - gameObject.transform.position).normalized;
            WSS.RocketLauncherAmmo-=1;
            Rigidbody shoot = Instantiate(Rocket, gameObject.transform.position, Quaternion.LookRotation(direction));
            //* Quaternion.Euler(RO)是臨時的
		    shoot.velocity = direction * speed;
		    Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), shoot.GetComponent<Collider>());
            LaunchTimer = 0;
        }
    }
    public override void AltFire()
    {
        
    }
}
