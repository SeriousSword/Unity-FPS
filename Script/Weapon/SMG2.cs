using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG2 : Shoot
{
    private Animator animator;
    private AudioSource audiosource;
    public AudioClip ShootSound;
    public Rigidbody BulletL;
    private float ShootRate = 1/10f;
    private float ShootTimer = 0f;
    public GameObject Leftshootpoint;
    private GameObject SMGMainPart;
    float speed = 100f;
    float ShootWaitTime = 1/20f;
    public ParticleSystem GunfireL;
    public RectTransform CrossCenter;
    public Camera PlayerCamera;
    public GameObject WS;
    private WeaponSwitcher WSS;
    void Start()
    {
        WSS =WS.GetComponent<WeaponSwitcher>();
        SMGMainPart = GameObject.Find("SMG");
        animator = GameObject.Find("SMG").GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
        ShootRate = 1/10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (ShootTimer<ShootRate)
        {
            ShootTimer += Time.deltaTime;
        }
        if(WSS.SMGAmmo>=2)
        {
            MainFire();
        }
          
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Double: Fire"))
        {
            GunfireL.Stop();
        }
    }
    public override void MainFire()
    {
        Vector2 ScreenPoint = RectTransformUtility.WorldToScreenPoint(null, CrossCenter.position);
        Vector3 ViewportPoint = PlayerCamera.ScreenToViewportPoint(ScreenPoint);
        Ray ray = PlayerCamera.ViewportPointToRay(ViewportPoint);
        
        if(Input.GetMouseButtonUp (0)||Input.GetMouseButtonUp (1) || WSS.SMGAmmo <=1) 
        {
            audiosource.Stop();
            GunfireL.Stop();
        }
        else if (Input.GetMouseButtonDown (0) && Input.GetMouseButtonDown (1))
        {
            audiosource.clip = ShootSound;
            audiosource.Play();
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Double: Fire")&& ShootTimer>=ShootRate)
        {
            ShootTimer = 0;
            GunfireL.Play();
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
            StartCoroutine(WaitShoot());
            Vector3 direction = (targetPoint - Leftshootpoint.transform.position).normalized;
            WSS.SMGAmmo-=1;
            Rigidbody shootL = Instantiate(BulletL, Leftshootpoint.transform.position, Quaternion.LookRotation(direction)) as Rigidbody;  	
		    shootL.velocity = direction * speed;
		    Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), shootL.GetComponent<Collider>());
        }
        
    }
    public override void AltFire()
    {
        
    }
    private IEnumerator WaitShoot()
    {
        yield return new WaitForSeconds(ShootWaitTime);
      
    }
}
