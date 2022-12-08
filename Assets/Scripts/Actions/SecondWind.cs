using System.Collections;
using System.Collections.Generic;
using Creatures;
using UnityEngine;

public class SecondWind : BonusAction
{
    public new Fighter sourceCreature;

    public override void Use(Creature target)
    {
        sourceCreature.Heal(new DieExpression("1d10+5"));
        sourceCreature.HasSecondWind = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
