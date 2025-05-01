using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadSceneText : MonoBehaviour
{
    public GameObject introPanel; // 加載介面
    public List<GameObject> objectsToHide; // 需要隱藏的場景物件列表
    public TextAsset TextFile; 
    private TMP_Text TextContent; 
    public GameObject TextObject;

    void Start()
    {
        // 顯示加載介面並隱藏場景物件
        Time.timeScale = 0f;
        TextContent = TextObject.GetComponent<TMP_Text>();
        LoadContent();
        introPanel.SetActive(true);
        SetObjectsActive(false); // 隱藏場景物件
    }

    // 隱藏加載介面並顯示場景物件
    public void HideIntro()
    {
        Time.timeScale = 1f;
        introPanel.SetActive(false); // 隱藏加載介面
        SetObjectsActive(true); // 顯示場景物件
    }

    // 控制列表中物件的顯示或隱藏
    private void SetObjectsActive(bool isActive)
    {
        foreach (GameObject obj in objectsToHide)
        {
            if (obj != null)
            {
                obj.SetActive(isActive);
            }
        }
    }
    public void LoadContent()
    {
        TextContent.text = TextFile.text;
    }
    
}
