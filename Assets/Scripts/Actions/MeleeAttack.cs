using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Action
{
    public int attack = 0;
    public int damage = 0;
    public override void Use(Creature target)
    {
        attack = Dice.dice.Roll(1, 20);
        int attackTot = attack + sourceCreature.GetAttackBonus();
        Debug.Log("Attack roll: " + attack);
        if(attack == 20)
        {
            damage = Dice.dice.Roll(2, 8);
            int t2 = damage + sourceCreature.GetDamageBonus();
            target.TakeDamage(t2);
        }
        else if(attackTot >= target.GetArmorClass())
        {
            damage = Dice.dice.Roll(1, 8);
            int t2 = damage + sourceCreature.GetDamageBonus();
            Debug.Log("Damage roll: " + t2);
            target.TakeDamage(t2);
        }
        else
        {
            damage = 0;
        }
    }

    private void Awake()
    {
        targetPositions.Add(1);
        targetPositions.Add(2);
        sourcePositions.Add(1);
        sourcePositions.Add(2);
        TargetsAllies = false;
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
