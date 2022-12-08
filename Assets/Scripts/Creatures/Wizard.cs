using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Creature
{
    public int MaxSpellPoints;
    public int CurrentSpellPoints;
    

    public override void Die()
    {
        throw new System.NotImplementedException();
    }

    public override void EnterDying()
    {
        throw new System.NotImplementedException();
    }

    public override int GetDamageBonus()
    {
        return Dexterity;
    }

    internal override int GetSpellAttackBonus()
    {
        return Intelligence + ProficiencyBonus;
    }

}
