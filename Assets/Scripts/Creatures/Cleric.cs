using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleric : Creature
{
    public bool HasChannelDivinity;
    public int MaxSpellPoints;
    public int CurrentSpellPoints;
    public override void Act(string action, Creature target)
    {
        this.Actions[0].Use(target);
    }

    public override void BonusAct(string bonusAction, Creature target)
    {

    }

    public override void FreeAct(string freeAction, Creature target)
    {
    }


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
        return Strength;
    }

    public new int GetSpellSaveDC()
    {
        return 8 + Wisdom + ProficiencyBonus;
    }

    //public override void TakeDamage(int damage)
    //{
    //    CurrentHealth -= damage;
    //}

    internal override int GetSpellAttackBonus()
    {
        return Wisdom + ProficiencyBonus;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void ShortRest()
    {
        base.ShortRest();
        
        Debug.Log("Getting some EELing.");
    }
}
