using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    public void Click()
	{
        SceneManager.LoadSceneAsync(0);
    }	
}
