using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class EndTurn : EndTurnAction
{
    //public Button button;

    //public EndTurnContainer container;

    //public ActionsContainer actionContainer;
    public override void Use()
    {
        FinishTurn();
    }

    // Start is called before the first frame update


    public void FinishTurn()
    {
        sourceCreature.EndTurn();
    }



    // Update is called once per frame
    void Update()
    {

    }
}
