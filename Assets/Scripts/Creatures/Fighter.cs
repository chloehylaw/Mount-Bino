using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : Creature
{
    public bool HasSecondAttack;

    public override void Act(Action action, Creature target)
    {
        if (IsActionSurging)
        {
            IsActionSurging = false;
        }
        else
        {
            HasAction = false;
        }
        action.Use();
    }

    public void Attack_Temp(Creature target)
    {
        //this.Actions[0].Use(target);
    }

    public override void Die()
    {
        Destroy(gameObject);
    }

    public override void EnterDying()
    {
        throw new System.NotImplementedException();
    }

    public override int GetDamageBonus()
    {
        return Strength + StatusEffectDamageBonus;
    }

    internal override int GetSpellAttackBonus()
    {
        return Intelligence + ProficiencyBonus;
    }
}
