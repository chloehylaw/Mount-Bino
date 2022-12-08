using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestButton : MonoBehaviour
{
    public Animator transition;

    [SerializeField] private AudioSource selectSoundEffect;

    public float transitionTime = 1f;

    public void BackToMap()
    {
        selectSoundEffect.Play();
        StartCoroutine(LoadLevel(3));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
