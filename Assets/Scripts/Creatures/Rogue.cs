using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : Creature
{
    public override void Act(string action, Creature target)
    {
        this.Actions[0].Use(target);
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }

    public override void EndTurn()
    {
        TickStatuses();
        Debug.Log("Ending turn");
    }

    public override void EnterDying()
    {
        throw new System.NotImplementedException();
    }

    public override int GetArmorClass()
    {
        return ArmorClass;
    }

    public override int GetAttackBonus()
    {
        return Dexterity + ProficiencyBonus;
    }

    public override int GetDamageBonus()
    {
        return Dexterity + Dice.dice.Roll(3, 6);
    }

   
    //public override void TakeDamage(int damage)
    //{
    //    CurrentHealth -= damage;
    //}

    public override void TickStatuses()
    {
        throw new System.NotImplementedException();
    }

    internal override int GetInitiativeBonus()
    {
        return Dexterity;
    }

    internal override int GetSpellAttackBonus()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

   
}