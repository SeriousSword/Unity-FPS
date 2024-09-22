using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelathAndArmor : MonoBehaviour
{
    public float Health;
    public float Armor;
    private float rate = 0.1f;
    private float FireTimer = 0f;
    public bool test = false;
    private AudioSource audiosource;
    public AudioClip HPSound;
    public AudioClip APSound;
    public AudioClip BulletSound;
    public AudioClip ChainSound;
    public AudioClip ShellSound;
    public AudioClip FuelSound;
    public AudioClip RocketSound;
    public bool DamageRise = false;
    private WeaponSwitcher WS;
    void Start()
    {
        Health = 100;
        Armor = 0;
        DamageRise = false;
        test = false;
        audiosource = GetComponent<AudioSource>();
        WS=GameObject.Find("WeaponSwitch").GetComponent<WeaponSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health<=0)
        {
            SceneManager.LoadSceneAsync(2);
        }
        if (FireTimer<=rate)
        {
            FireTimer += Time.deltaTime;
        }
        
    }
    public void DamageCount(float Damage)
    {
        if(DamageRise == true)
        {
            Damage*=1.2f;
        }
        test = true;
        if (Armor>=Damage)
        {
            Armor -= Damage;
            Damage =0;
            test = false;
        }
        else
        {
            float RemainDamage =Damage-Armor;
            float ArmorDamage = Armor;
            Armor -=ArmorDamage;
            Health -=RemainDamage; 
            test = false;
        }   
    }
    void OnTriggerStay(Collider other) 
    {
        if (other.tag == "BuffMachineFlame")
        {
            if (FireTimer<=rate)
            {
                return;
            }
            float Damage = 1;
            DamageCount(Damage);
            FireTimer = 0f;
        } 
    }
    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "RocketRange")
        {
            float Damage = 25;
            DamageCount(Damage);
        }
        if (other.tag == "SmallFlyAttack")
        {
            float Damage = 30;
            DamageCount(Damage);
        }
        else if (other.tag == "SmallBallAttack")
        {
            float Damage = 20;
            DamageCount(Damage);
        }
        else if (other.tag == "SmallBallFire")
        {
            float Damage = 15;
            DamageCount(Damage);
        }
        else if (other.tag == "FlyBombAttack")
        {
            float Damage = 45;
            DamageCount(Damage);
        }
        else if (other.tag == "ThunderAttack")
        {
            float Damage = 40;
            DamageCount(Damage);
        }
        else if (other.tag == "BigLightGroundAttack")
        {
            float Damage = 80;
            DamageCount(Damage);
        }
        else if (other.tag == "BigLightThoundAttack")
        {
            float Damage = 50;
            DamageCount(Damage);
        }
        else if (other.tag == "BigSmokeSmokeAttack")
        {
            float Damage = 30;
            DamageCount(Damage);
        }
        else if (other.tag == "BigSmokeJumpAttack")
        {
            float Damage = 60;
            DamageCount(Damage);
        }
        else if (other.tag == "GroundExplodeAttack")
        {
            float Damage = 30;
            DamageCount(Damage);
        }


        else if (other.tag == "5HP")
        {
            audiosource.clip = HPSound;
            audiosource.Play();
            if (Health<=195)
            {
                Health+=5;
            }
            else if (Health<= 199)
            {
                Health += (200-Health);
            }
        }
        else if (other.tag == "25HP")
        {
            audiosource.clip = HPSound;
            audiosource.Play();
            if (Health<=75)
            {
                Health+=5;
            }
            else if (Health<= 99)
            {
                float x = 100-Health;
                Health += x;
            }
        }
        else if (other.tag == "50HP")
        {
            audiosource.clip = HPSound;
            audiosource.Play();
            if (Health<=50)
            {
                Health+=5;
            }
            else if (Health<= 99)
            {
                float x = 100-Health;
                Health += x;
            }
        }
        else if (other.tag == "100HP")
        {
            audiosource.clip = HPSound;
            audiosource.Play();
            if (Health<= 99)
            {
                float x = 100-Health;
                Health += x;
            }
        }


        else if (other.tag == "5AP")
        {
            audiosource.clip = APSound;
            audiosource.Play();
            if (Armor<=195)
            {
                Armor+=5;
            }
            else if (Armor<= 199)
            {
                Armor += (200-Armor);
            }
        }
        else if (other.tag == "25AP")
        {
            audiosource.clip = APSound;
            audiosource.Play();
            if (Armor<=75)
            {
                Armor+=5;
            }
            else if (Armor<= 99)
            {
                float x = 100-Armor;
                Armor += x;
            }
        }
        else if (other.tag == "50AP")
        {
            audiosource.clip = APSound;
            audiosource.Play();
            if (Armor<=50)
            {
                Armor+=5;
            }
            else if (Armor<= 99)
            {
                float x = 100-Armor;
                Armor += x;
            }
        }
        else if (other.tag == "100AP")
        {
            audiosource.clip = APSound;
            audiosource.Play();
            if (Armor<= 99)
            {
                float x = 100-Armor;
                Armor += x;
            }
        }

        
        else if(other.tag == "200BulletChain")
        {
            audiosource.clip = ChainSound;
            audiosource.Play();
            if (WS.MinigunAmmo<=WS.MinigunAmmoLimit-200)
            {
                WS.MinigunAmmo+=200;
            }
            else if (WS.MinigunAmmo<=WS.MinigunAmmoLimit)
            {
                float x = WS.MinigunAmmoLimit-WS.MinigunAmmo;
                WS.MinigunAmmo += x;
            }
        }
        else if(other.tag == "100Bullet")
        {
            audiosource.clip = BulletSound;
            audiosource.Play();
            if (WS.SMGAmmo<=WS.SMGAmmoLimit-100)
            {
                WS.SMGAmmo+=100;
            }
            else if (WS.SMGAmmo<=WS.SMGAmmoLimit)
            {
                float x = WS.SMGAmmoLimit-WS.SMGAmmo;
                WS.SMGAmmo += x;
            }
        }
        else if (other.tag =="20Shell")
        {
            audiosource.clip = ShellSound;
            audiosource.Play();
            if (WS.ShotgunAmmo<=WS.ShotgunAmmoLimit-20)
            {
                WS.ShotgunAmmo+=20;
            }
            else if (WS.ShotgunAmmo<=WS.ShotgunAmmoLimit)
            {
                float x = WS.ShotgunAmmoLimit-WS.ShotgunAmmo;
                WS.ShotgunAmmo += x;
            }
        }
        else if(other.tag =="100Fuel")
        {
            audiosource.clip = FuelSound;
            audiosource.Play();
            if (WS.FlameThrowerAmmo<=WS.FlameThrowerAmmoLimit-100)
            {
                WS.FlameThrowerAmmo+=100;
            }
            else if (WS.FlameThrowerAmmo<=WS.FlameThrowerAmmoLimit)
            {
                float x = WS.FlameThrowerAmmoLimit-WS.FlameThrowerAmmo;
                WS.FlameThrowerAmmo += x;
            }
        }
        else if(other.tag =="10Rocket")
        {
            audiosource.clip = RocketSound;
            audiosource.Play();
            if (WS.RocketLauncherAmmo<=WS.RocketLauncherAmmoLimit-10)
            {
                WS.RocketLauncherAmmo+=10;
            }
            else if (WS.RocketLauncherAmmo<=WS.RocketLauncherAmmoLimit)
            {
                float x = WS.RocketLauncherAmmoLimit-WS.RocketLauncherAmmo;
                WS.RocketLauncherAmmo += x;
            }
        }
    }
}
