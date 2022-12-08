using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : Creature
{
    public bool IsActionSurging;
    public bool HasActionSurge;
    public bool HasSecondWind;
    public bool HasSecondAttack;
    public override void Act(string action, Creature target)
    {

    }

    public override void BonusAct(string bonusAction, Creature target)
    {
    }
    public override void FreeAct(string freeAction, Creature target)
    {
    }
    public override void EndTurnAct(string endTurnAction, Creature target)
    {
    }

    public void Attack_Temp(Creature target)
    {
        this.Actions[0].Use(target);
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
