using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PASS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentsInChildren<Transform>(true).Length <= 1)
        {
            SceneManager.LoadSceneAsync(3);
        }
    }
}
