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
    public enum AbilityScores { Strength, Dexterity, Constitution, Intelligence, Charisma, Wisdom };
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
        if (FindObjectsOfType<GameHandler>().Length > 1)
            Destroy(gameObject);
        gameHandler = GetComponent<GameHandler>();
        DontDestroyOnLoad(gameObject);
        Party[0] = Instantiate(Fighter, transform);
        Party[1] = Instantiate(Rogue, transform);
        Party[2] = Instantiate(Wizard, transform);
        Party[3] = Instantiate(Cleric, transform);
        //CombatHandler.combatHandler.StartCombat(Party, Enemies);
    }

    public void enterCombatScene (string enemies)
    {
        Debug.Log(enemies);
        CombatEncounter encounter = Resources.Load<CombatEncounter>(enemies);
        Enemies.Capacity = encounter.enemies.Count;
        for(int i = 0; i < encounter.enemies.Count; i++)
        {
            Enemies[i] = Instantiate(encounter.enemies[i], transform);
        }
        Debug.Log(Enemies.ToString());
        SceneManager.LoadScene("Combat");
        StartCoroutine(StartCombatAfterSceneLoad());
    }

    public IEnumerator StartCombatAfterSceneLoad()
    {
        while (!SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("Combat")))
        {
            yield return null;
        }
        CombatHandler.combatHandler.StartCombat(Party, Enemies);
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
