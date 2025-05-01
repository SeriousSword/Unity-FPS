using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SMG : Shoot
{
    public Animator animator;
    public GameObject PB;
    private PlayerMove PM;
    public GameObject WS;
    private WeaponSwitcher WSS;
    private AudioSource audiosource;
    public AudioClip ShootSound;
    public Rigidbody BulletR;
    public Rigidbody BulletL;
    private float ShootRate = 1/10f;
    private float ShootTimer = 0f;
    public GameObject Leftshootpoint;
    public GameObject Rightshootpoint;
    public ParticleSystem GunfireR;
    float speed = 100f;
    public RectTransform CrossCenter;
    public Camera PlayerCamera;
    
    void Start()
    {
        PM = PB.GetComponent<PlayerMove>();
        WSS =WS.GetComponent<WeaponSwitcher>();
        audiosource = GetComponent<AudioSource>();
        ShootRate = 1/10f;
    }

    void Update()
    {
        if (ShootTimer<ShootRate)
        {
            ShootTimer += Time.deltaTime;
        }
        float x = PM.x;//input水平
        float z = PM.z;//input垂直
        if(WSS.SMGAmmo>=1)
        {
            MainFire(); 
        }
        AltFire();
        if (x != 0f || z != 0f)
        {
            animator.SetBool("Moving",true);
        }
        else
        {
            animator.SetBool("Moving",false);
        }
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Double: Fire")&&!animator.GetCurrentAnimatorStateInfo(0).IsName("Single: Fire"))
        {
            GunfireR.Stop();
        }
    }
    public override void MainFire()
    {
        Vector2 ScreenPoint = RectTransformUtility.WorldToScreenPoint(null, CrossCenter.position);
        Vector3 ViewportPoint = PlayerCamera.ScreenToViewportPoint(ScreenPoint);
        Ray ray = PlayerCamera.ViewportPointToRay(ViewportPoint);
        

        if (Input.GetMouseButtonDown (0))
        {
            animator.SetBool("Fire",true);
            audiosource.clip = ShootSound;
            audiosource.Play();
        }
        if ((animator.GetCurrentAnimatorStateInfo(0).IsName("Single: Fire") ||animator.GetCurrentAnimatorStateInfo(0).IsName("Double: Fire"))&& ShootTimer>=ShootRate )
        {
            ShootTimer = 0;
            GunfireR.Play();
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
            Vector3 direction = (targetPoint - Rightshootpoint.transform.position).normalized;
            WSS.SMGAmmo-=1;
            Rigidbody shootR = Instantiate(BulletR, Rightshootpoint.transform.position, Quaternion.LookRotation(direction)) as Rigidbody;  	
		    shootR.velocity = direction * speed;
		    Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), shootR.GetComponent<Collider>());
            
        }
        if (Input.GetMouseButtonUp (0) ||WSS.SMGAmmo <=0)
        {
            GunfireR.Stop();
            animator.SetBool("Fire",false);
            audiosource.Stop();
        }
       
        
    }
    public override void AltFire()
    {
        if (Input.GetMouseButton (1))
        {
            animator.SetBool("Double",true);
            //ShootRate = DoubleRate;

        }
        else if (Input.GetMouseButtonUp (1))
        {
            animator.SetBool("Double",false);
            //ShootRate = SingleRate;
        }
    }
}
