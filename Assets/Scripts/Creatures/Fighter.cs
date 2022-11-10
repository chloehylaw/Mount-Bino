using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : Creature
{
    public override void Act(string action, Creature target)
    {
    }

    public void Attack_Temp(Creature target)
    {
        this.Actions[0].Use(target);
    }

    public override int GetArmorClass()
    {
        return ArmorClass;
    }

    public override int GetAttackBonus()
    {
        return Strength + ProficiencyBonus;
    }

    public override int GetDamageBonus()
    {
        return Strength + 2; //Dueling
    }

    public override void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
    }

    // Start is called before the first frame update
    void Awake()
    {
        Strength = 4;
        Dexterity = 1;
        Constitution = 3;
        Intelligence = -1;
        Wisdom = 1;
        Charisma = 0;
        ArmorClass = 18;
        MaxHealth = 49;
        CurrentHealth = 49;
        ProficiencyBonus = 3;
        Name = "The Fighter";
        //Actions = new List<Action>();
    }
    


    // Update is called once per frame
    void Update()
    {
        
    }
}
