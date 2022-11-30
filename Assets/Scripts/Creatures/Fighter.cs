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

    public override void Die()
    {
        Destroy(gameObject);
    }

    public override void EnterDying()
    {
        throw new System.NotImplementedException();
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

    public override void StartTurn()
    {
        throw new System.NotImplementedException();
    }

    public override void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        healthBar.SetHealth(CurrentHealth);
    }

    public override void TickStatuses()
    {
        throw new System.NotImplementedException();
    }

    internal override int GetInitiativeBonus()
    {
        return Dexterity;
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
