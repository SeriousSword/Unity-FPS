using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    private KeyCode SMGKey = KeyCode.Alpha1;
    public GameObject SMG;
    private KeyCode ShotgunKey = KeyCode.Alpha2;
    public GameObject Shotgun;
    private KeyCode FlameThrowerKey = KeyCode.Alpha3;
    public GameObject FlameThrower;
    private KeyCode MinigunKey = KeyCode.Alpha4;
    public GameObject Minigun;
    private KeyCode RocketLauncherKey = KeyCode.Alpha5;
    public GameObject RocketLauncher;
    public GameObject ShotgunMainPart;
    public GameObject ShotgunBarrelPart;
    private Vector3 originalEulerAngles;
    public float SMGAmmo= 600;
    public float ShotgunAmmo= 120;
    public float FlameThrowerAmmo= 800;
    public float MinigunAmmo= 1000;
    public float RocketLauncherAmmo = 60;
    public float SMGAmmoLimit = 600;
    public float ShotgunAmmoLimit = 120;
    public float FlameThrowerAmmoLimit = 800;
    public float MinigunAmmoLimit = 1000;
    public float RocketLauncherAmmoLimit = 60;
    public bool RocketExplosion;
    public GameObject Ammo;
    private SMGPoint smgPoint;
    private ShotgunPoint shotgunPoint;
    private FlamePoint flamePoint;
    private MinigunPoint minigunPoint;
    private RocketLauncherPoint rocketLauncherPoint;

    
    void Start()
    {
        smgPoint = Ammo.GetComponent<SMGPoint>();
        shotgunPoint = Ammo.GetComponent<ShotgunPoint>();
        flamePoint = Ammo.GetComponent<FlamePoint>();
        minigunPoint = Ammo.GetComponent<MinigunPoint>();
        rocketLauncherPoint =Ammo.GetComponent<RocketLauncherPoint>();
        originalEulerAngles = transform.localEulerAngles;
        SMG.SetActive(true);
        Shotgun.SetActive(false);
        FlameThrower.SetActive(false);
        Minigun.SetActive(false);
        RocketLauncher.SetActive(false);

        smgPoint.enabled = true;
        shotgunPoint.enabled = false;
        flamePoint.enabled = false;
        minigunPoint.enabled = false;
        rocketLauncherPoint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(SMGKey))
        {
            SMG.SetActive(true);
            Shotgun.SetActive(false);
            FlameThrower.SetActive(false);
            Minigun.SetActive(false);
            RocketLauncher.SetActive(false);

            smgPoint.enabled = true;
            shotgunPoint.enabled = false;
            flamePoint.enabled = false;
            minigunPoint.enabled = false;
            rocketLauncherPoint.enabled = false;

            RocketExplosion = false;
            ShotgunBarrelPart.transform.localEulerAngles = originalEulerAngles;
            ShotgunMainPart.transform.localEulerAngles = originalEulerAngles;
        }
        else if (Input.GetKeyDown(ShotgunKey))
        {
            ShotgunBarrelPart.transform.localEulerAngles = originalEulerAngles;
            ShotgunMainPart.transform.localEulerAngles = originalEulerAngles;

            SMG.SetActive(false);
            Shotgun.SetActive(true);
            FlameThrower.SetActive(false);
            Minigun.SetActive(false);
            RocketLauncher.SetActive(false);

            smgPoint.enabled = false;
            shotgunPoint.enabled = true;
            flamePoint.enabled = false;
            minigunPoint.enabled = false;
            rocketLauncherPoint.enabled = false;
            
            RocketExplosion = false;
        }
        else if (Input.GetKeyDown(FlameThrowerKey))
        {
            SMG.SetActive(false);
            Shotgun.SetActive(false);
            FlameThrower.SetActive(true);
            Minigun.SetActive(false);
            RocketLauncher.SetActive(false);

            smgPoint.enabled = false;
            shotgunPoint.enabled = false;
            flamePoint.enabled = true;
            minigunPoint.enabled = false;
            rocketLauncherPoint.enabled = false;

            RocketExplosion = false;
            ShotgunBarrelPart.transform.localEulerAngles = originalEulerAngles;
            ShotgunMainPart.transform.localEulerAngles = originalEulerAngles;
        }
        else if(Input.GetKeyDown(MinigunKey))
        {
            SMG.SetActive(false);
            Shotgun.SetActive(false);
            FlameThrower.SetActive(false);
            Minigun.SetActive(true);
            RocketLauncher.SetActive(false);

            smgPoint.enabled = false;
            shotgunPoint.enabled = false;
            flamePoint.enabled = false;
            minigunPoint.enabled = true;
            rocketLauncherPoint.enabled = false;

            RocketExplosion = false;
            ShotgunBarrelPart.transform.localEulerAngles = originalEulerAngles;
            ShotgunMainPart.transform.localEulerAngles = originalEulerAngles;
        }
        else if (Input.GetKeyDown(RocketLauncherKey))
        {
            SMG.SetActive(false);
            Shotgun.SetActive(false);
            FlameThrower.SetActive(false);
            Minigun.SetActive(false);
            RocketLauncher.SetActive(true);

            smgPoint.enabled = false;
            shotgunPoint.enabled = false;
            flamePoint.enabled = false;
            minigunPoint.enabled = false;
            rocketLauncherPoint.enabled = true;

            RocketExplosion = true;
            ShotgunBarrelPart.transform.localEulerAngles = originalEulerAngles;
            ShotgunMainPart.transform.localEulerAngles = originalEulerAngles;
        }
    }
}
