using System.Collections;
using System.Collections.Generic;
using Creatures;
using UnityEngine;

public class SecondWind : BonusAction
{

    public override void Use()
    {
        sourceCreature.Heal(new DieExpression("1d10+5"));
        sourceCreature.HasSecondWind = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
