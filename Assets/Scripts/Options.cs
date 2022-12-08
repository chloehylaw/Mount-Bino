using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    public float volume;
    public AudioMixer mixer;

    public static Options instance;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);     // makes sure that the music keeps on playing after reloading scenes

        if (instance == null)       // if there is no music starts music
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);        // ensures that the music is not duplicated by not restarting the music again once reloading the scene
        }
    }

    public void SetVolume(float volume)
    {
        mixer.SetFloat("Volume", volume);
    }

}
