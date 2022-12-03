using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler gameHandler;
    public List<Creature> Party;
    public List<Creature> Enemies;

    public Creature Fighter;
    public Creature Rogue;
    public Creature Wizard;
    public Creature Cleric;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
