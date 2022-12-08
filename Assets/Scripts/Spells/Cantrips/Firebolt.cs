using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Firebolt : Spell, IAttack
{
    readonly int DamageDiceSize = 10;
    readonly int DamageDiceAmount = 2;
    readonly int DamageBonus = 0;
    
    public void Attack(Creature target, Creature source, int DamageDiceSize, int DamageDiceAmount, int DamageBonus, int AttackBonus, int Advantage = 0)
    {
        throw new System.NotImplementedException();
    }

    public override void Cast(List<Creature> targets)
    {
        Attack(targets[0], sourceCreature, DamageDiceSize, DamageDiceAmount, DamageBonus, sourceCreature.GetSpellAttackBonus());
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
