using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : Creature
{
    public override void Act(string action, Creature target)
    {
        this.Actions[0].Use(target);
    }


    public override void BonusAct(string bonusAction, Creature target)
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
        return Dexterity + Dice.dice.Roll(3, 6);
    }

   
    //public override void TakeDamage(int damage)
    //{
    //    CurrentHealth -= damage;
    //}


    internal override int GetSpellAttackBonus()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

   
}
