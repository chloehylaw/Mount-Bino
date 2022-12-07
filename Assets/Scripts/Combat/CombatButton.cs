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

    public void EndTurn()
    {
        button.interactable = false;
        //CombatHandler.combatHandler.AdvanceTurn();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
