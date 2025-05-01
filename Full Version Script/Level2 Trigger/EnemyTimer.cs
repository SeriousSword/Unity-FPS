using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTimer : MonoBehaviour
{
    float T =0f;
    public GameObject Next;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        T+=Time.deltaTime;
        if(T>=25f && Next!=null)
        {
            Next.SetActive(true);

        }
        if (GetComponentsInChildren<Transform>(true).Length <= 1 )
        {
            if(Next!=null)
            {
                Next.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
