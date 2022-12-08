using UnityEngine;
using TMPro;
using Unity.VisualScripting;

namespace Stats
{
    public class Stats : MonoBehaviour
    {
        public GameObject Fighter;
        public GameObject Rogue;
        public GameObject Wizard;
        public GameObject Cleric;

        private TextMeshProUGUI fighterStats;
        private TextMeshProUGUI rogueStats;
        private TextMeshProUGUI wizardStats;
        private TextMeshProUGUI clericStats;

        private string currentFighterStats;
        private string currentRogueStats;
        private string currentWizardStats;
        private string currentClericStats;
        
        void Start()
        {
            fighterStats = Fighter.GetComponent<TextMeshProUGUI>();
            rogueStats = Rogue.GetComponent<TextMeshProUGUI>();
            wizardStats = Wizard.GetComponent<TextMeshProUGUI>();
            clericStats = Cleric.GetComponent<TextMeshProUGUI>();
        }

        void Update()
        {
            fighterStats.text = GetFighterStats();
            rogueStats.text = GetRogueStats();
            wizardStats.text = GetWizardStats();
            clericStats.text = GetClericStats();
        }

        public void clickMap ()
        {
            GameHandler.gameHandler.EnterMapScene();
        }

        private string GetFighterStats()
        {
            var health = GameHandler.gameHandler.Fighter.CurrentHealth;
            var strength = GameHandler.gameHandler.Fighter.Strength;
            var dexterity = GameHandler.gameHandler.Fighter.Dexterity;
            var constitution = GameHandler.gameHandler.Fighter.Constitution;
            var intelligence = GameHandler.gameHandler.Fighter.Intelligence;
            var wisdom = GameHandler.gameHandler.Fighter.Wisdom;
            var charisma = GameHandler.gameHandler.Fighter.Charisma;

            currentFighterStats = "Health: " + health + "\n" +
                                  "Strength: " + strength + "\n" +
                                  "Dexterity: " + dexterity + "\n" +
                                  "Constitution: " + constitution + "\n" +
                                  "Intelligence: " + intelligence + "\n" +
                                  "Wisdom: " + wisdom + "\n" +
                                  "Charisma: " + charisma;

            return currentFighterStats;
        }
        
        private string GetRogueStats()
        {
            var health = GameHandler.gameHandler.Rogue.CurrentHealth;
            var strength = GameHandler.gameHandler.Rogue.Strength;
            var dexterity = GameHandler.gameHandler.Rogue.Dexterity;
            var constitution = GameHandler.gameHandler.Rogue.Constitution;
            var intelligence = GameHandler.gameHandler.Rogue.Intelligence;
            var wisdom = GameHandler.gameHandler.Rogue.Wisdom;
            var charisma = GameHandler.gameHandler.Rogue.Charisma;

            currentRogueStats = "Health: " + health + "\n" +
                                  "Strength: " + strength + "\n" +
                                  "Dexterity: " + dexterity + "\n" +
                                  "Constitution: " + constitution + "\n" +
                                  "Intelligence: " + intelligence + "\n" +
                                  "Wisdom: " + wisdom + "\n" +
                                  "Charisma: " + charisma;

            return currentRogueStats;
        }
        
        private string GetWizardStats()
        {
            var health = GameHandler.gameHandler.Wizard.CurrentHealth;
            var strength = GameHandler.gameHandler.Wizard.Strength;
            var dexterity = GameHandler.gameHandler.Wizard.Dexterity;
            var constitution = GameHandler.gameHandler.Wizard.Constitution;
            var intelligence = GameHandler.gameHandler.Wizard.Intelligence;
            var wisdom = GameHandler.gameHandler.Wizard.Wisdom;
            var charisma = GameHandler.gameHandler.Wizard.Charisma;

            currentWizardStats = "Health: " + health + "\n" +
                                "Strength: " + strength + "\n" +
                                "Dexterity: " + dexterity + "\n" +
                                "Constitution: " + constitution + "\n" +
                                "Intelligence: " + intelligence + "\n" +
                                "Wisdom: " + wisdom + "\n" +
                                "Charisma: " + charisma;

            return currentWizardStats;
        }
        
        private string GetClericStats()
        {
            var health = GameHandler.gameHandler.Cleric.CurrentHealth;
            var strength = GameHandler.gameHandler.Cleric.Strength;
            var dexterity = GameHandler.gameHandler.Cleric.Dexterity;
            var constitution = GameHandler.gameHandler.Cleric.Constitution;
            var intelligence = GameHandler.gameHandler.Cleric.Intelligence;
            var wisdom = GameHandler.gameHandler.Cleric.Wisdom;
            var charisma = GameHandler.gameHandler.Cleric.Charisma;

            currentClericStats = "Health: " + health + "\n" +
                                 "Strength: " + strength + "\n" +
                                 "Dexterity: " + dexterity + "\n" +
                                 "Constitution: " + constitution + "\n" +
                                 "Intelligence: " + intelligence + "\n" +
                                 "Wisdom: " + wisdom + "\n" +
                                 "Charisma: " + charisma;

            return currentClericStats;
        }
        
        
    }
}
