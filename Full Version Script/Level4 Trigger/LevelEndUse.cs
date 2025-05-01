using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelEndUse : MonoBehaviour
{
    private KeyCode UseKey = KeyCode.E;
    private bool Ent = false;
    public GameObject UI;
    private PlayerMove PM;
    private PlayerLook PL;
    public GameObject Body;
    public GameObject Cam;
    public GameObject Water;
    public GameObject Dust;
    public GameObject Weapon;
    void Start()
    {
        UI.SetActive(false);
        PM = Body.GetComponent<PlayerMove>();
        PL = Cam.GetComponent<PlayerLook>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Ent == true && Input.GetKeyDown(UseKey))
        {
            StartCoroutine(FightEnd());
            Dust.SetActive(false);
            PM.enabled =false;
            PL.enabled =false;
            Weapon.SetActive(false);
            //Body.transform.position = new Vector3(517.1f, 150.8f, 268.2f);
            Body.transform.position = Water.transform.position;
            Body.transform.rotation = Quaternion.Euler(20f, 0f, 0f);
            Cam.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Water.SetActive(true);
            Weapon.SetActive(false);
            
            //gameObject.SetActive(false);
            
        }
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag =="PlayerBody")
        {
            Ent = true;
            UI.SetActive(true);
        }
        
    }
    
    void OnTriggerExit(Collider other) 
    {
        UI.SetActive(false);
        Ent = false;
    }
    IEnumerator FightEnd()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadSceneAsync(0);
    }
}
