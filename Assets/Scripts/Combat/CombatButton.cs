using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatButton : MonoBehaviour
{
    public UnityEngine.UI.Button button;
    
    // Start is called before the first frame update
    void Awake()
    {
        button = gameObject.GetComponent<UnityEngine.UI.Button>();
    }

    public void StartTurn()
    {
        button.interactable = true;
    }

    public void SkipCombat()
    {
        var temp = FindObjectsOfType<Creature>();
        foreach(Creature creature in temp)
        {
            if (!GameHandler.gameHandler.Party.Contains(creature))
                Destroy(creature.gameObject);
        }
        GameHandler.gameHandler.EnterMapScene();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
