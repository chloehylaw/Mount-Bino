using System.Collections.Generic;
using System.Data;
using System.Globalization;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


namespace RandomEvents
{
    public class EventScenario : MonoBehaviour
    {
        public GameObject Setting;
        public GameObject Answer;
        public GameObject Scenario;
        public GameObject SettingOptionA;
        public GameObject SettingOptionB;
        public GameObject AnswerOptionA;
        public GameObject AnswerOptionB;
        public GameObject Result;
        
        private TextMeshProUGUI settingScenario;
        private TextMeshProUGUI settingOptionA;
        private TextMeshProUGUI settingOptionB;
        private TextMeshProUGUI answerOptionA;
        private TextMeshProUGUI answerOptionB;
        private TextMeshProUGUI answerResult;
        
        public TextAsset textJson;
        private SceneList scenes = new SceneList();

        private int scenesLength;
        private int diceRoll;
        
        [System.Serializable]
        public class Scene
        {
            public string scenario;
            public string optionA;
            public string optionB;
            public List<AnswerA> answerA;
            public List<AnswerB> answerB;
        }
        
        [System.Serializable]
        public class AnswerA
        {
            public string story;
            public List<Actions> actions;
        }
        
        [System.Serializable]
        public class AnswerB
        {
            public string story;
            public List<Actions> actions;
        }
        
        [System.Serializable]
        public class Actions
        {
            public string fighter;
            public string rogue;
            public string wizard;
            public string cleric;
        }
        
        [System.Serializable]
        public class SceneList
        {
            public Scene[] scene;
        }
        
        void Start()
        {
            settingScenario = Scenario.GetComponent<TextMeshProUGUI>();
            settingOptionA = SettingOptionA.GetComponentInChildren<TextMeshProUGUI>();
            settingOptionB = SettingOptionB.GetComponentInChildren<TextMeshProUGUI>();
            answerOptionA = AnswerOptionA.GetComponent<TextMeshProUGUI>();
            answerOptionB = AnswerOptionB.GetComponent<TextMeshProUGUI>();
            answerResult = Result.GetComponent<TextMeshProUGUI>();

            scenes = JsonUtility.FromJson<SceneList>(textJson.text);

            scenesLength = scenes.scene.Length;
            // Debug.Log("scene length: " + scenesLength);
            //diceRoll = Random.Range(0, scenesLength);
            diceRoll = 1;
            Debug.Log("dice roll: " + diceRoll);
        }

        void Update()
        {
            settingScenario.text = scenes.scene[diceRoll].scenario;
            settingOptionA.text = scenes.scene[diceRoll].optionA;
            settingOptionB.text = scenes.scene[diceRoll].optionB;
        }

        public void clickMap ()
        {
            SceneManager.LoadScene("Map");
        }

        public void clickOptionA ()
        {
            displayAnswer();
            answerResult.text = findAction(scenes.scene[diceRoll].answerA[0].actions);
        }

        public void clickOptionB ()
        {
            displayAnswer();
            answerResult.text = findAction(scenes.scene[diceRoll].answerB[0].actions);
        }

        private void displayAnswer ()
        {
            Setting.SetActive(false);
            Answer.SetActive(true);

            answerOptionA.text = scenes.scene[diceRoll].answerA[0].story;
            answerOptionB.text = scenes.scene[diceRoll].answerB[0].story;
        }

        private string findAction (List<Actions> action)
        {
            bool hasAction = false;
            string actionResult = "";
            if (!string.IsNullOrEmpty(action[0].fighter))
            {
                Debug.Log("Fighter " + action[0].fighter);
                actionResult += "Fighter " + action[0].fighter;
                hasAction = true;
            }
            if (!string.IsNullOrEmpty(action[0].rogue))
            {
                Debug.Log("Rogue " +  action[0].rogue);
                actionResult += "\nRogue " + action[0].rogue;
                hasAction = true;

            }
            if (!string.IsNullOrEmpty(action[0].wizard))
            {
                Debug.Log("Wizard " +  action[0].wizard);
                actionResult += "\nWizard " + action[0].wizard;
                hasAction = true;
            }
            if (!string.IsNullOrEmpty(action[0].cleric))
            {
                Debug.Log("Cleric " +  action[0].cleric);
                actionResult += "\nCleric " + action[0].cleric;
                hasAction = true;
            }
            return hasAction ? actionResult : "No effect";
        }

        
    }
}
