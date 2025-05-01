using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelMenu : MonoBehaviour
{
    public GameObject Mainmenu;
    public void ClickLevel1()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void ClickLevel2()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void ClickLevel3()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void ClickLevel4()
    {
        SceneManager.LoadSceneAsync(4);
    }
    public void ClickLevel5()
    {
        SceneManager.LoadSceneAsync(5);
    }
    public void ClickLastPage()
    {
        Mainmenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
