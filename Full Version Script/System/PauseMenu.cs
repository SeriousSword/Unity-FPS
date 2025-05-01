using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject ControllUI;
    public GameObject Weapon;

    private bool isPaused = false;
    private bool ControllOpened = false;
    void Start()
    {
        Cursor.lockState =CursorLockMode.Locked;
        Cursor.visible = false;
        ControllUI.SetActive(false);
        menuUI.SetActive(false);
    }

    void LateUpdate()
    {
        if (!isPaused)
        {
            Cursor.lockState =CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    void Update()
    {
        // Detect if the player presses the Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(ControllOpened)
            {
                CloseControll();
            }
            else if (isPaused)
            {
                ResumeGame(); // If the game is paused, resume the game
                
            }
            else
            {
                PauseGame();  // Otherwise, pause the game
            }
        }
        
    }

    // Method to pause the game
    public void PauseGame()
    {  
        menuUI.SetActive(true);    // Show the pause menu
        Cursor.lockState =CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;       // Freeze the game by setting time scale to 0
        Weapon.SetActive(false);
        isPaused = true;           // Set the isPaused flag to true
    }

    // Method to resume the game
    public void ResumeGame()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1f;       // Resume the game by setting time scale back to 1
        Weapon.SetActive(true);
        isPaused = false;          // Set the isPaused flag to false
        
    }

    // Method for exiting the game (can be called from UI buttons)
    public void QuitGame()
    {
        Application.Quit(); // Exits the game
        Debug.Log("Game Quit!");   // For testing, logs the message in the editor
    }
    public void ReturnMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void OpenControll()
    {
        menuUI.SetActive(false);
        ControllUI.SetActive(true);
        ControllOpened = true;
    }
    public void CloseControll()
    {
        menuUI.SetActive(true);
        ControllUI.SetActive(false);
        ControllOpened = false;
    }
}
