using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    public int Strength;
    public int Dexterity;
    public int Constitution;
    public int Intelligence;
    public int Wisdom;
    public int Charisma;
    public int ArmorClass;
    public string Name;
    public int MaxHealth;
    public int CurrentHealth;
    public int ProficiencyBonus;
    public List<Action> Actions;
    public List<Spell> Spells;
    public List<Status> Statuses;
    public Weapon EquippedWeapon;
    public event System.Action OnStartTurn;

    internal abstract int GetSpellAttackBonus();

    // Start is called before the first frame update
    void Start() 
    { 
        foreach (var action in Actions)
        {
            action.sourceCreature = this;
        }

    }
    public abstract int GetArmorClass();
    public abstract void Die();
    public abstract void EnterDying();
    public abstract void EndTurn();
    public abstract int GetAttackBonus();
    public abstract int GetDamageBonus();
    internal Weapon GetWeapon()
    {
        return EquippedWeapon;
    }
    internal abstract int GetInitiativeBonus();
    public abstract void TakeDamage(int damage);
    public abstract void Act(string action, Creature target);
    public abstract void TickStatuses();
    public void StartTurn()
    {
        OnStartTurn?.Invoke();
        //TickStatuses();
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
