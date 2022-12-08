using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public MusicControllerMenu musicControllerMenu;

    public Animator transition;

    public float transitionTime = 1f;

    void Start()
    {
        // Allows the cursor to be always visible when the main menu opens
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void StartCampaign()
    {
        Destroy(musicControllerMenu);
        StartCoroutine(LoadLevel(3));
        Debug.Log("Starting Campaign + Destroy Music");
    }
    public void Options()
    {
        StartCoroutine(LoadLevel(2));
        Debug.Log("Opening Options");
    }

    public void Credits()
    {
        Debug.Log("Opening Credits");
        StartCoroutine(LoadLevel(1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
