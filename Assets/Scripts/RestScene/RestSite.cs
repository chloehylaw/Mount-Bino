using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace RestScene
{
    public class RestSite : MonoBehaviour
    {

        private float timer = 3f;
        private TextMeshProUGUI timerSeconds; 
        void Start()
        {
            timerSeconds = GetComponent<TextMeshProUGUI>();
        }

        void Update()
        {
            timer -= Time.deltaTime;
            timerSeconds.text = timer.ToString("f0");
            if (timer <= 0)
            {
                SceneManager.LoadScene("Map");
            }
        }
    }
}
