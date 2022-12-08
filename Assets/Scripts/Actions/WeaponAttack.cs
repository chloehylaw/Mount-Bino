using System;
using System.Collections;
using System.Collections.Generic;
using Creatures;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Weapon attacks. They use the creature's equipped weapon to determine range and damage.
/// </summary>
public class WeaponAttack : Action, IAttack
{
    Creature targetCreature;
    void Start()
    {
        //sourceCreature = gameObject.GetComponent<Creature>();
        button = gameObject.GetComponent<Button>();
        targetPositions = sourceCreature.GetWeapon().Targets;
        sourcePositions = sourceCreature.GetWeapon().Positions;
        MousePosition2D.OnMouseClick += ReturnClickedCreature;
    }

    public void Attack(Creature target, Creature source, int DamageDiceSize, int DamageDiceAmount, int DamageBonus, int AttackBonus, int Advantage = 0)
    {
        if(Dice.dice.Roll(1,20, source.StatusEffectAttackAdvantage) + source.GetAttackBonus() >= target.GetArmorClass())
        {
            target.TakeDamage(Dice.dice.Roll(DamageDiceAmount, DamageDiceSize) + source.GetDamageBonus());
        }
    }

    public override void Use()
    {
        StartCoroutine(WaitForTarget());
        if(targetPositions.Contains(CombatHandler.combatHandler.EnemyPositions.IndexOf(targetCreature)))
            Attack(targetCreature, sourceCreature, sourceCreature.GetWeapon().DamageDiceSize, sourceCreature.GetWeapon().DamageDiceAmount, sourceCreature.GetDamageBonus(), sourceCreature.GetAttackBonus());

    }

    public IEnumerator WaitForTarget()
    {
        while(targetCreature == null)
        {
            yield return null;
        }
    }

    public void ReturnClickedCreature(Creature c)
    {
        targetCreature = c;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
