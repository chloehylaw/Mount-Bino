using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicControllerMenu : MonoBehaviour
{
    public static MusicControllerMenu instance;
    
    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex != 3)
        {
            Debug.Log("The active scene is: " + SceneManager.GetActiveScene().buildIndex);
            DontDestroyOnLoad(this.gameObject);     // makes sure that the music keeps on playing after reloading scenes
        }

        if (instance == null)       // if there is no music starts music
        {
            instance = this;
        }
        else
        {
            Debug.Log("copy of music is destroyed");
            Destroy(gameObject);        // ensures that the music is not duplicated by not restarting the music again once reloading the scene
        }
    }
}
