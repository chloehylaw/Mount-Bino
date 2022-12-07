using System.Collections;
using System.Collections.Generic;
using RandomEvents;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static GameHandler gameHandler;
    public List<Creature> Party;
    public List<Creature> Enemies;
    public enum AbilityScores { Strength, Dexterity, Consitytion, Intelligence, Charisma, Wisdom };
    public Creature Fighter;
    public Creature Rogue;
    public Creature Wizard;
    public Creature Cleric;
    
    public List<string> minorEnemyEncounters;
    public List<string> eliteEnemyEncounters;
    public List<string> specialistEnemyEncounters;
    public List<string> bossEnemyEncounters;

    public List<string> eventEncounters;

    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GetComponent<GameHandler>();
        DontDestroyOnLoad(gameObject);
        Party[0] = Instantiate(Fighter);
        Party[1] = Instantiate(Rogue);
        Party[2] = Instantiate(Wizard);
        Party[3] = Instantiate(Cleric);
        Enemies[0] = Instantiate(Fighter);
        Enemies[1] = Instantiate(Rogue);
        Enemies[2] = Instantiate(Wizard);
        Enemies[3] = Instantiate(Cleric);
        CombatHandler.combatHandler.StartCombat(Party, Enemies);
    }

    public void enterCombatScene (string enemies)
    {
        Debug.Log(enemies);
        CombatEncounter encounter = Resources.Load<CombatEncounter>(enemies);
        Enemies = encounter;
        Debug.Log(Enemies.ToString());
        SceneManager.LoadScene("Combat");
        //CombatHandler.combatHandler.StartCombat(Party, Enemies);
    }

    public void enterRestScene ()
    {
        SceneManager.LoadScene("RestSite"); 
    }

    public void enterEventScene ()
    {
        SceneManager.LoadScene("RandomEvent");
    }

    public void enterMapScene ()
    {
        SceneManager.LoadScene("Map");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
