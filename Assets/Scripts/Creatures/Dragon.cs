using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Creature
{

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


    //public override void TakeDamage(int damage)
    //{
    //    CurrentHealth -= damage;
    //}

    internal override int GetSpellAttackBonus()
    {
        return Intelligence + ProficiencyBonus;
    }

    // Start is called before the first frame update
    void Start()
    {

    }


}
