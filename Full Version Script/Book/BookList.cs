using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BookList : MonoBehaviour
{
    
    public TextAsset TextFile; 
    private TMP_Text TextContent; 
    public GameObject TextObject;
    public Sprite ImageFile;
    private Image ImageContent;
    public GameObject ImageObject;
    

    void Start()
    {
        ImageContent = ImageObject.GetComponent<Image>();
        TextContent = TextObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadContent()
    {
        ImageContent.sprite =ImageFile;
        TextContent.text = TextFile.text;
    }
}
