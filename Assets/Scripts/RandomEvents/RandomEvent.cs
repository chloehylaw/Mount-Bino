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

        public GameObject Fighter;
        public GameObject Rogue;
        public GameObject Wizard;
        public GameObject Cleric;

        private Creature clericStatus = new Cleric();
        private Creature fighterStatus = new Fighter();
        private Creature rogueStatus = new Rogue();
        private Creature wizardStatus = new Wizard();
        
        private TextMeshProUGUI optionA;
        private TextMeshProUGUI optionB;
        
        private string gameObjectName;
        
        
        public void Start ()
        {
            gameObjectName = gameObject.name;
            Debug.Log(gameObjectName);

            optionA = AnswerOptionA.GetComponent<TextMeshProUGUI>();
            optionB = AnswerOptionB.GetComponent<TextMeshProUGUI>();

        }

        public void Update ()
        {
            //Debug.Log("GameObject: " + gameObjectName);
            switch (gameObjectName)
            {
            case "RandomEvent_0(Clone)":
                // something
                break;
            case "RandomEvent_1(Clone)":
                // something
                break;
            case "RandomEvent_2(Clone)":
                // something
                break;
            }
        }

        public void clickOptionA ()
        {
            int diceRoll;
            displayAnswer();
            AnswerOptionA.SetActive(true);
            
            switch (gameObjectName)
            {
            case "RandomEvent_0(Clone)":
            {
                diceRoll = GameHandler.gameHandler.Rogue.MakeDexterityCheck();
                if (diceRoll > 15)
                {
                    optionA.text = "Success! Dice rolled: " + diceRoll + "\nRogue Dexterity +1";
                    GameHandler.gameHandler.Rogue.Dexterity += 1;

                } else
                {
                    optionA.text = "Failed! Dice rolled: " + diceRoll + "\nRogue Dexterity -1";
                    GameHandler.gameHandler.Rogue.Dexterity -= 1;
                }
                break;
            }
            case "RandomEvent_1(Clone)":
            {
                diceRoll = GameHandler.gameHandler.Rogue.MakeDexterityCheck();
                if (diceRoll > 13)
                {
                    optionA.text = "Success! Dice rolled: " + diceRoll + "\nRogue Dexterity +1";
                    GameHandler.gameHandler.Rogue.Dexterity += 1;
                } else
                {
                    optionA.text = "Failed! Dice rolled: " + diceRoll + "\nRogue Dexterity -1";
                    GameHandler.gameHandler.Rogue.Dexterity -= 1;
                }
                break;
            }
            case "RandomEvent_2(Clone)":
                diceRoll = GameHandler.gameHandler.Cleric.MakeWisdomCheck();
                if (diceRoll > 15)
                {
                    optionA.text = "Success! Dice rolled: " + diceRoll + "\nCleric Wisdom +1";
                    GameHandler.gameHandler.Rogue.Wisdom += 1;
                } else
                {
                    optionA.text = "Failed! Dice rolled: " + diceRoll + "\nCleric Wisdom -1";
                    GameHandler.gameHandler.Rogue.Wisdom -= 1;
                }
                break;
            }
        }
        
        public void clickOptionB ()
        {
            int diceRoll;
            displayAnswer();
            AnswerOptionB.SetActive(true);
            
            switch (gameObjectName)
            {
            case "RandomEvent_0(Clone)":
                optionB.text = "Nothing happens.";
                // Nothing happens
                break;
            case "RandomEvent_1(Clone)":
            {
                diceRoll = GameHandler.gameHandler.Fighter.MakeStrengthCheck();
                if (diceRoll > 13)
                {
                    optionA.text = "Success! Dice rolled: " + diceRoll + "\nFighter Strength +1";
                    GameHandler.gameHandler.Fighter.Strength += 1;
                } else
                {
                    optionA.text = "Failed! Dice rolled: " + diceRoll + "\nFighter Strength -1";
                    GameHandler.gameHandler.Fighter.Strength -= 1;
                }
                break;
            }
            case "RandomEvent_2(Clone)":
                diceRoll = GameHandler.gameHandler.Wizard.MakeWisdomCheck();
                if (diceRoll > 15)
                {
                    optionB.text = "Success! Dice rolled: " + diceRoll + "\nWizard Wisdom +1";
                    GameHandler.gameHandler.Wizard.Wisdom += 1;
                } else
                {
                    optionB.text = "Failed! Dice rolled: " + diceRoll + "\nWizard Wisdom -1";
                    GameHandler.gameHandler.Wizard.Wisdom -= 1;
                }
                break;
                break;
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
