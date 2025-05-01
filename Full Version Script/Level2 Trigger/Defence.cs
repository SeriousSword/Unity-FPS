using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defence : MonoBehaviour
{
    public GameObject Enemy;
    public Rigidbody Bullet;
    public float speed = 200f;
    public float ShootRate = 1/10f;
    private float ShootTimer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemy != null)
        {
            FaceEnemy();
            ShootTimer += Time.deltaTime;
            if(ShootTimer>=ShootRate)
            {
                ShootTimer =0f;
                Fire();
            }
            
        }
    }
    void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.layer ==LayerMask.NameToLayer("enemy"))
        {
            if(Enemy == null)
            {
                Enemy =other.gameObject;
            }
            else if((Enemy.transform.position - transform.position).sqrMagnitude > (other.transform.position - transform.position).sqrMagnitude)
            {
                Enemy =other.gameObject;
            }
        }
    }
    void Fire()
    {
        Vector3 direction = (Enemy.transform.position - gameObject.transform.position).normalized;
        Rigidbody shoot = Instantiate(Bullet, gameObject.transform.position, Quaternion.LookRotation(direction));  	
        shoot.velocity = direction * speed;
        Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), shoot.GetComponent<Collider>());
    }
    void FaceEnemy()
    {
        Vector3 directionToFace = Enemy.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(directionToFace);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 6f);
    }
}
