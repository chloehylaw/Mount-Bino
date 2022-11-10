using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Action
{

    public override void Use(Creature target)
    {
        int attack = Dice.Roll(1, 20) + sourceCreature.GetAttackBonus();
        Debug.Log("Attack roll: " + attack);
        if(attack >= target.GetArmorClass())
        {
            int t2 = Dice.Roll(1, 8) + sourceCreature.GetDamageBonus();
            Debug.Log("Damage roll: " + t2);
            target.TakeDamage(t2);
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
