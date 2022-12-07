using System.Collections;
using System.Collections.Generic;
using RandomEvents;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
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
        /*Party[0] = Instantiate(Fighter);
        Party[1] = Instantiate(Rogue);
        Party[2] = Instantiate(Wizard);
        Party[3] = Instantiate(Cleric);
        Enemies[0] = Instantiate(Fighter);
        Enemies[1] = Instantiate(Rogue);
        Enemies[2] = Instantiate(Wizard);
        Enemies[3] = Instantiate(Cleric);*/
        //CombatHandler.combatHandler.StartCombat(Party, Enemies);
    }

    public void enterCombatScene (string enemies)
    {
        Debug.Log(enemies);
        CombatEncounter encounter = Resources.Load<CombatEncounter>(enemies);
        Enemies = new List<Creature>(encounter.enemies);
        for (int i = 0; i < encounter.enemies.Count; i++)
        {
            Enemies[i] = Instantiate(encounter.enemies[i]);
        }
        Debug.Log(Enemies.ToString());
        SceneManager.LoadScene("Combat");
        StartCoroutine(StartCombatAfterSceneLoad());
    }
    public IEnumerator StartCombatAfterSceneLoad ()
    {
        while (!SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("Combat")))
        {
            yield return null;
        }
        CombatHandler.combatHandler.StartCombat(Party, Enemies);
    }

    public void enterEventScene (string eventPath)
    {
        Debug.Log(eventPath);
        /*RandomEventEncounter encounter = Resources.Load<RandomEventEncounter>(eventPath);
        Event = encounter.events.AddComponent<RandomEvent>();
        Event = Instantiate(encounter.events);
        Debug.Log(Event.ToString());
        Instantiate(Resources.Load(eventPath));*/
        
        SceneManager.LoadScene("RandomEvent");
        //RandomEventHandler.randomEventHandler.StartEvent(eventPath);
        StartCoroutine(StartEventAfterSceneLoad(eventPath));
    }

    public IEnumerator StartEventAfterSceneLoad (string eventPath)
    {
        while (!SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("RandomEvent")))
        { 
            yield return null;
        }
        //Instantiate(Resources.Load(eventPath));
        RandomEventHandler.randomEventHandler.StartEvent(eventPath);
    }
    
    public void enterRestScene ()
    {
        SceneManager.LoadScene("RestSite"); 
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
