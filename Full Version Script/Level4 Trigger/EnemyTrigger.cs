using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject se;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag =="PlayerBody")
        {
            if(Enemy!=null)
            {
                Enemy.SetActive(true);
                Destroy(se,1);
            }
        }
        
    }
}
