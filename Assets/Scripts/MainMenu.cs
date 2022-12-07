using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public MusicControllerMenu musicControllerMenu;
    void Start()
    {
        // Allows the cursor to be always visible when the main menu opens
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void StartCampaign()
    {
        Destroy(musicControllerMenu);
        SceneManager.LoadScene(3);
        Debug.Log("Starting Campaign + Destroy Music");
    }
    public void Options()
    {
        SceneManager.LoadScene(2);
        Debug.Log("Opening Options");
    }

    public void Credits()
    {
        Debug.Log("Opening Credits");
        SceneManager.LoadScene(1);
    }
}
