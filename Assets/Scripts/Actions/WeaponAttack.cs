using System;
using System.Collections;
using System.Collections.Generic;
using Creatures;
using UnityEngine;
/// <summary>
/// Weapon attacks. They use the creature's equipped weapon to determine range and damage.
/// </summary>
public class WeaponAttack : Action, IAttack
{

    public void Attack(Creature target, Creature source, int DamageDiceSize, int DamageDiceAmount, int DamageBonus, int AttackBonus, int Advantage = 0)
    {
        throw new NotImplementedException();
    }

    public override void Use(Creature target)
    {
        Attack(target, sourceCreature, sourceCreature.GetWeapon().DamageDiceSize, sourceCreature.GetWeapon().DamageDiceAmount, sourceCreature.GetDamageBonus(), sourceCreature.GetAttackBonus());
    }

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        sourceCreature = GetComponent<Creature>();
        targetPositions = sourceCreature.GetWeapon().Targets;
        sourcePositions = sourceCreature.GetWeapon().Positions;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
