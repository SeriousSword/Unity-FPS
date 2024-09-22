using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float BOMBTime = 3f;
    private float Timer = 0f;
    public MeshRenderer mesh;
    private AudioSource audiosource;
    public AudioClip HitEnemySound;
    public LayerMask EnemyLayer;
    public GameObject HitParticle;
    private bool x =false;
    void Start()
    {
        
        Timer = 0f;
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer>=BOMBTime)
        {
            Destroy(gameObject,1);
        }
        Timer+=Time.deltaTime;
        Vector3 direction = transform.forward;
        float distanceToTravel = 100f * Time.deltaTime;
        RaycastHit hit;
        
        if (!x&&Physics.Raycast(transform.position, direction, out hit, distanceToTravel+2.3f))
        {
            // 檢測到碰撞，產生特效

            if (x==false)
            {
                var lauFx = Instantiate(HitParticle, hit.point, Quaternion.identity);
                x =true;
                Destroy(lauFx,1);
            } 
        }

    }

    //void OnCollisionEnter(Collision collision) 
    void OnTriggerEnter(Collider other) 
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        //對特定敵人做出反應
        if(other.tag == "BuffMachineFlame")
        {
            Destroy(gameObject);
        }
        //打到人的聲音
        if(((1 << other.gameObject.layer) & EnemyLayer) != 0)
        {
            audiosource.clip = HitEnemySound;
            audiosource.Play();
        }
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        mesh.enabled =false;
        //碰撞後消失
        Destroy(gameObject,0);
    }
}
