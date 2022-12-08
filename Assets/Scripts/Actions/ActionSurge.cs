using System.Collections;
using System.Collections.Generic;
using Creatures;
using UnityEngine;

public class ActionSurge : FreeAction
{
    public new Fighter sourceCreature;
    public override void Use(Creature target)
    {
        sourceCreature.IsActionSurging = true;
        sourceCreature.HasActionSurge = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
