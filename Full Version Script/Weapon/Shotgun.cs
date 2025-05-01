using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shotgun : Shoot
{
    public Animator animator;
    public GameObject PB;
    private PlayerMove PM;
    public GameObject WS;
    private WeaponSwitcher WSS;
    private AudioSource audiosource;
    public AudioClip SingleSound;
    public AudioClip DoubleSound;
    public AudioClip ReloadSound;
    public float Shell = 2f;
    public Rigidbody ShootShell;
    //private float ReloadingTime = 0.5f;
    public GameObject ShotgunBarrelPart;
    private GameObject[] SingleShoot;
    private GameObject[] DoubleShoot;
    private float speed = 100f;
    public GameObject SinglePaticle;
    public GameObject DoublePaticle;
    public GameObject ShootPoint;
    public GameObject Center;
    public RectTransform CrossCenter;
    public Camera PlayerCamera;
    void Start()
    {
        PM = PB.GetComponent<PlayerMove>();
        WSS =WS.GetComponent<WeaponSwitcher>();
        audiosource = GetComponent<AudioSource>();
        SingleShoot = GameObject.FindGameObjectsWithTag("ShotgunSingleShoot");
        DoubleShoot = GameObject.FindGameObjectsWithTag("ShotgunDoubleShoot");
    }

    void Update()
    {
        float x = PM.x;//input水平
        float z = PM.z;//input垂直
        if (Shell <= 0f)
        {
            animator.SetBool("Reload",true);
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Reload"))
            {
                audiosource.clip = ReloadSound;
                audiosource.Play();
                Shell = 2f;
                animator.SetBool("Reload",false);
                
            }
        }        
        if (Input.GetMouseButtonDown (0))
        {
            MainFire();
        }
        if (Input.GetMouseButtonDown (1))
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
        Vector2 ScreenPoint = RectTransformUtility.WorldToScreenPoint(null, CrossCenter.position);
        Vector3 ViewportPoint = PlayerCamera.ScreenToViewportPoint(ScreenPoint);
        Ray ray = PlayerCamera.ViewportPointToRay(ViewportPoint);
        if (Shell>0&&!animator.GetCurrentAnimatorStateInfo(0).IsName("DoubleShoot")&&!animator.GetCurrentAnimatorStateInfo(0).IsName("Reload") &&WSS.ShotgunAmmo>=1)
        {
            animator.Play("SingleShoot",-1,0f);
            //animator.SetInteger("FireType",1);
            //animator.SetTrigger("Fire");
            audiosource.clip = SingleSound;
            audiosource.Play();
            foreach (GameObject obj in SingleShoot)
            {
                RaycastHit hit;
                Vector3 targetPoint;
                if (Physics.Raycast(ray, out hit))
                {
                    targetPoint = hit.point;
                }
                else
                {
                    targetPoint = ray.GetPoint(100); 
                }
                Vector3 direction = (targetPoint - gameObject.transform.position).normalized;
                
                Center.transform.rotation = Quaternion.LookRotation(direction);
                
                var shoFx = Instantiate (SinglePaticle, ShootPoint.transform.position, ShootPoint.transform.rotation );
                Rigidbody shoot = Instantiate(ShootShell, obj.transform.position, obj.transform.rotation);  	
		        shoot.velocity = obj.transform.TransformDirection(new Vector3( 0, 0, speed));
		        Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), shoot.GetComponent<Collider>());
            }
            WSS.ShotgunAmmo-=1;
            Shell-=1;
        }
        
    }
    public override void AltFire()
    {
        Vector2 ScreenPoint = RectTransformUtility.WorldToScreenPoint(null, CrossCenter.position);
        Vector3 ViewportPoint = PlayerCamera.ScreenToViewportPoint(ScreenPoint);
        Ray ray = PlayerCamera.ViewportPointToRay(ViewportPoint);
        if (Shell==1&&!animator.GetCurrentAnimatorStateInfo(0).IsName("DoubleShoot")&&!animator.GetCurrentAnimatorStateInfo(0).IsName("Reload")&&WSS.ShotgunAmmo>=1)
        {
            animator.Play("SingleShoot",-1,0f);
            //animator.SetInteger("FireType",1);
            //animator.SetTrigger("Fire");
            audiosource.clip = SingleSound;
            audiosource.Play();
            foreach (GameObject obj in SingleShoot)
            {
                RaycastHit hit;
                Vector3 targetPoint;
                if (Physics.Raycast(ray, out hit))
                {
                    targetPoint = hit.point;
                }
                else
                {
                    targetPoint = ray.GetPoint(100); // 如果没有碰撞，目标点设为射线的远点
                }
                Vector3 direction = (targetPoint - gameObject.transform.position).normalized;
                Center.transform.rotation = Quaternion.LookRotation(direction);
                var shoFx = Instantiate (SinglePaticle, ShootPoint.transform.position, ShootPoint.transform.rotation);
                
                Rigidbody shoot = Instantiate(ShootShell, obj.transform.position, obj.transform.rotation) ;  	
		        shoot.velocity = obj.transform.TransformDirection(new Vector3( 0, 0, speed));
		        Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), shoot.GetComponent<Collider>());
            }
            WSS.ShotgunAmmo-=1;
            Shell-=1;
        }
        else if (Shell==2&&!animator.GetCurrentAnimatorStateInfo(0).IsName("SingleShoot")&&!animator.GetCurrentAnimatorStateInfo(0).IsName("Reload")&&WSS.ShotgunAmmo>=2)
        {
            animator.Play("DoubleShoot",-1,0f);
            //animator.SetInteger("FireType",1);
            //animator.SetTrigger("Fire");
            audiosource.clip = DoubleSound;
            audiosource.Play();
            RaycastHit hit;
            Vector3 targetPoint;
            if (Physics.Raycast(ray, out hit))
            {
                targetPoint = hit.point;
            }
            else
            {
                targetPoint = ray.GetPoint(100); // 如果没有碰撞，目标点设为射线的远点
            }
            Vector3 direction = (targetPoint - gameObject.transform.position).normalized;
            Center.transform.rotation = Quaternion.LookRotation(direction);
            foreach (GameObject obj in SingleShoot)
            {
                var shoFx = Instantiate (DoublePaticle, ShootPoint.transform.position, ShootPoint.transform.rotation);
                
                Rigidbody shoot = Instantiate(ShootShell, obj.transform.position, obj.transform.rotation) ;  	
		        shoot.velocity = obj.transform.TransformDirection(new Vector3( 0, 0, speed));
		        Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), shoot.GetComponent<Collider>());
            }
            foreach (GameObject obj2 in DoubleShoot)
            {
                var shoFx = Instantiate (DoublePaticle, ShootPoint.transform.position, ShootPoint.transform.rotation);
                Rigidbody shoot = Instantiate(ShootShell, obj2.transform.position, obj2.transform.rotation) ;  	
		        shoot.velocity = obj2.transform.TransformDirection(new Vector3( 0, 0, speed));
		        Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), shoot.GetComponent<Collider>());
            }
            WSS.ShotgunAmmo-=2;
            Shell-=2;
        }
        /*
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Moving") ||animator.GetCurrentAnimatorStateInfo(0).IsName("Standing"))
        {
            if (Shell == 1)
            {
                
                animator.SetInteger("FireType",1);
                animator.SetTrigger("Fire");
                Shell-=1;
            }
            else if(Shell == 2)
            {
                
                animator.SetInteger("FireType",2);
                animator.SetTrigger("Fire");
                Shell-=2;
            }
            
        }
        */
    }
}
