using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectLeave : MonoBehaviour
{
    public GameObject Introduce;
    public GameObject PlayerUI;
    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (gameObject.activeSelf)
        {
            Cursor.lockState =CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    void Update()
    {
        
    }
    public void CloseMenu()
    {
        
        PlayerUI.SetActive(true);
        Cursor.lockState =CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        Introduce.SetActive(false);
    }
}
