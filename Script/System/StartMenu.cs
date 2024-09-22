using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void ClickStartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    //按下此按鈕，離開遊戲
    public void ClickExitGame()
    {
        Application.Quit();
    }
}
