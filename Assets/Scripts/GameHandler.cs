using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler gameHandler;
    public List<Creature> Party;
    public List<Creature> Enemies;
    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GetComponent<GameHandler>();
        DontDestroyOnLoad(gameObject);
        CombatHandler.combatHandler.StartCombat(Party, Enemies);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
