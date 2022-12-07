using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace RandomEvents
{
    public class RandomEvent : MonoBehaviour
    {
        public GameObject Setting;
        public GameObject Answer;
        public GameObject AnswerOptionA;
        public GameObject AnswerOptionB;

        public GameObject SelectPlayer;
        public GameObject Fighter;
        public GameObject Rogue;
        public GameObject Wizard;
        public GameObject Cleric;

        private TextMeshProUGUI selectPlayer;
        
        private string gameObjectName;
        
        
        public void Start ()
        {
            gameObjectName = gameObject.name;
            Debug.Log(gameObjectName);

            selectPlayer = SelectPlayer.GetComponent<TextMeshProUGUI>();

        }

        public void Update ()
        {
            if (gameObjectName == "RandomEvent_0")
            {
                Fighter.SetActive(false);
                Rogue.SetActive(true);
                Wizard.SetActive(false);
                Cleric.SetActive(false);
            }
        }

        public void clickOptionA ()
        {
            displayAnswer();
            AnswerOptionA.SetActive(true);
            
            if (gameObjectName == "RandomEvent_0")
            {
                // Update Rogue status
            }
        }
        
        public void clickOptionB ()
        {
            displayAnswer();
            AnswerOptionB.SetActive(true);
            
            if (gameObjectName == "RandomEvent_0")
            {
                // Nothing happens
            }
        }
        
        private void displayAnswer ()
        {
            Setting.SetActive(false);
            Answer.SetActive(true);
        }

        public void selectFighter ()
        {
            // Get Fighter status
            
            
        }

        public void selectRogue ()
        {
            // Get Rogue status
        }

        public void selectWizard ()
        {
            // Get Wizard status
        }

        public void selectCleric ()
        {
            // Get Cleric status
        }
        
        public void clickMap ()
        {
            GameHandler.gameHandler.enterMapScene();
        }
    }
}
