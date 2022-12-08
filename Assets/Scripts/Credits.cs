using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class Credits : MonoBehaviour
{
    public Animator transition;

    [SerializeField] private AudioSource selectSoundEffect;

    public float transitionTime = 1f;

    public void BackToMenu()
    {
        selectSoundEffect.Play();
        StartCoroutine(LoadLevel(0));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
