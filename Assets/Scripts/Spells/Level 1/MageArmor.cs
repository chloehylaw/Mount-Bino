using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Dice;

public class MageArmor : Spell
{
    public Status statusEffect;
    public override void Cast(List<Creature> targets)
    {
        statusEffect.SourceCreature = sourceCreature;
        statusEffect.AffectedBonuses.Add(sourceCreature.StatusEffectACBonus);
        statusEffect.Effect = new DieExpression(3.ToString());
        sourceCreature.Statuses.Add(statusEffect);
    }
}
