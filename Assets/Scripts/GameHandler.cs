using System.Collections;
using System.Collections.Generic;
using RandomEvents;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public GameObject overlay;
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

    private string currentSceneName;
    
    private bool enteredMap;
    private bool enteredStats;
    
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectsOfType<GameHandler>().Length > 1)
            Destroy(gameObject);
        gameHandler = GetComponent<GameHandler>();
        DontDestroyOnLoad(gameObject);
        Party[0] = Instantiate(Fighter, transform);
        Party[1] = Instantiate(Cleric, transform);
        Party[2] = Instantiate(Rogue, transform);
        Party[3] = Instantiate(Wizard, transform);
        Fighter = Party[0];
        Cleric = Party[1];
        Rogue = Party[2];
        Wizard = Party[3];
        MousePosition2D.OnMouseClick += testMouse;
        //CombatHandler.combatHandler.StartCombat(Party, Enemies);
    }

    public void Update()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        
        // Load overlay
        // Debug.Log(SceneManager.GetActiveScene().name);
        overlay.SetActive(currentSceneName != "MainMenu");
    }
    public void enterCombatScene (string enemies)
    {
        Debug.Log(enemies);
        CombatEncounter encounter = Resources.Load<CombatEncounter>(enemies);
        Enemies = encounter.enemies;
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

    public void testMouse(Creature c)
    {
        Debug.Log(c.Name);
    }
    public void enterEventScene (string eventPath)
    {
        Debug.Log(eventPath);
        
        SceneManager.LoadScene("RandomEvent");
        StartCoroutine(StartEventAfterSceneLoad(eventPath));
    }

    public IEnumerator StartEventAfterSceneLoad (string eventPath)
    {
        while (!SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("RandomEvent")))
        { 
            yield return null;
        }
        RandomEventHandler.randomEventHandler.StartEvent(eventPath);
    }
    
    public void enterRestScene ()
    {
        SceneManager.LoadScene("RestSite"); 
    }

    // event to stats or map back forth works
    
    public void EnterMapScene ()
    {
        if (currentSceneName == "Map")
        {
            // do nothing
        }
        else if (currentSceneName == "Map" && enteredMap == true)
        {
            SceneManager.UnloadSceneAsync("Map");
            Destroy(GameObject.Find("/OuterMapParent"));
            enteredMap = false;
        }
        else
        {
            if (enteredMap == false)
            {
                if (currentSceneName == "RandomEvent")
                {
                    RandomEventHandler.randomEventHandler.currentRandomEvent.SetActive(false);
                }

                if (currentSceneName == "Stats")
                {
                    GameObject.Find("/StatsInfo").SetActive(false);
                }
                SceneManager.LoadScene("Map", LoadSceneMode.Additive);
                enteredMap = true;
            }
            else
            {
                if (currentSceneName == "RandomEvent")
                {
                    RandomEventHandler.randomEventHandler.currentRandomEvent.SetActive(true);
                }
                if (currentSceneName == "Stats")
                {
                    GameObject.Find("/StatsInfo").SetActive(true);
                }
                SceneManager.UnloadSceneAsync("Map");
                Destroy(GameObject.Find("/OuterMapParent"));
                enteredMap = false;
            }
        }
    }
    
    public void EnterStatsScene()
    {
        if (currentSceneName == "Stats" && enteredStats == false)
        {
            // do nothing
        }
        else if (currentSceneName == "Stats" && enteredStats == true)
        {
            SceneManager.UnloadSceneAsync("Stats");
            enteredStats = false;
        }
        else
        {
            if (enteredStats == false)
            {
                if (currentSceneName == "RandomEvent")
                {
                    RandomEventHandler.randomEventHandler.currentRandomEvent.SetActive(false);
                }

                if (currentSceneName == "Map")
                {
                    GameObject.Find("/OuterMapParent").SetActive(false);
                    GameObject.Find("/LegendObjects").SetActive(false);
                }

                SceneManager.LoadScene("Stats",  LoadSceneMode.Additive);
                enteredStats = true;
            }
            else
            {
                if (currentSceneName == "RandomEvent")
                {
                    RandomEventHandler.randomEventHandler.currentRandomEvent.SetActive(true);
                }

                if (currentSceneName == "Map")
                {
                    GameObject.Find("/OuterMapParent").SetActive(true);
                    GameObject.Find("/LegendObjects").SetActive(true);
                }

                SceneManager.UnloadSceneAsync("Stats");
                enteredStats = false;
            }
        }
        
    }
}
