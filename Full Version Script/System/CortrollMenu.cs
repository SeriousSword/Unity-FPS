using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CortrollMenu : MonoBehaviour
{
    public GameObject Mainmenu;
    public void ClickLastPage()
    {
        Mainmenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
