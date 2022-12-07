using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTurn : MonoBehaviour
{
    public UnityEngine.UI.Button button;

    // Start is called before the first frame update
    void Awake()
    {
        button = gameObject.GetComponent<UnityEngine.UI.Button>();
    }

    public void FinishTurn()
    {
        CombatHandler.combatHandler.AdvanceTurn();
    }



    // Update is called once per frame
    void Update()
    {

    }
}
