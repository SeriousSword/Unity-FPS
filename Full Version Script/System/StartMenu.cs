using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject Levelmenu;
    public GameObject Controllmenu;
    public GameObject Bookmenu;
    public void ClickStartGame()
    {
        Levelmenu.SetActive(true);
        gameObject.SetActive(false);
    }
    public void ClickControll()
    {
        Controllmenu.SetActive(true);
        gameObject.SetActive(false);
    }
    public void ClickBook()
    {
        Bookmenu.SetActive(true);
        gameObject.SetActive(false);
    }

    //按下此按鈕，離開遊戲
    public void ClickExitGame()
    {
        Application.Quit();
    }
}
