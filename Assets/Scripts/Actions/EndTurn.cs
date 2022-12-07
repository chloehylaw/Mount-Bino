using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTurn : EndTurnAction
{
    //public Button button;

    //public EndTurnContainer container;

    //public ActionsContainer actionContainer;
    public override void Use(Creature target)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Awake()
    {
        //button = container.GetComponent<Button>();
        //button.onClick.AddListener(FinishTurn);
    }

    public void FinishTurn()
    {
        CombatHandler.combatHandler.AdvanceTurn();
        //actionContainer.enabled = false;
    }



    // Update is called once per frame
    void Update()
    {

    }
}
