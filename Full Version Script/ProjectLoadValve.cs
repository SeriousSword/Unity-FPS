using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ProjectLoadValve : MonoBehaviour
{
    public TextAsset TextFile; 
    private TMP_Text TextContent; 
    public GameObject TextObject;
    public Sprite ImageFile;
    private Image ImageContent;
    public GameObject ImageObject;
    public GameObject Introduce;
    public GameObject PlayerUI;
    private Vector2 maxResolution = new Vector2(900, 1050);
    void Start()
    {
        Time.timeScale = 0f;
        Cursor.lockState =CursorLockMode.None;
        Cursor.visible = true;
        ImageContent = ImageObject.GetComponent<Image>();
        TextContent = TextObject.GetComponent<TMP_Text>();
        ImageContent.sprite =ImageFile;
        TextContent.text = TextFile.text;
        Introduce.SetActive(true);
        PlayerUI.SetActive(false);
        Vector2 imageSize = ImageContent.sprite.rect.size;
        float scaleFactor = Mathf.Min(maxResolution.x / imageSize.x, maxResolution.y / imageSize.y);
        ImageContent.rectTransform.sizeDelta = imageSize * scaleFactor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
