using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Dice;

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
    public List<BonusAction> BonusActions;
    public List<BonusAction> FreeActions;
    public List<BonusAction> EndTurnActions;
    public List<Spell> Spells;
    public List<Status> Statuses;
    public Weapon EquippedWeapon;
    public event System.Action OnStartTurn;
    public event System.Action<int> OnTakeDamage;

    public int StatusEffectStrengthCheckAdvantage;
    public int StatusEffectDexterityCheckAdvantage;
    public int StatusEffectConstitutionCheckAdvantage;
    public int StatusEffectIntelligenceCheckAdvantage;
    public int StatusEffectWisdomCheckAdvantage;
    public int StatusEffectCharismaCheckAdvantage;
    public int StatusEffectStrengthSaveAdvantage;
    public int StatusEffectDexteritySaveAdvantage;
    public int StatusEffectConstitutionSaveAdvantage;
    public int StatusEffectIntelligenceSaveAdvantage;
    public int StatusEffectWisdomSaveAdvantage;
    public int StatusEffectCharismaSaveAdvantage;
    public int StatusEffectCheckAdvantage;
    public int StatusEffectAttackAdvantage;
    public int StatusEffectSaveAdvantage;
    public DieExpression StatusEffectCheckBonus;
    public DieExpression StatusEffectAttackBonus;
    public DieExpression StatusEffectSaveBonus;


    internal abstract int GetSpellAttackBonus();

    

    // Start is called before the first frame update
    void Start() 
    { 
        foreach (var action in Actions)
        {
            action.sourceCreature = this;
        }

        foreach (var bonusAction in BonusActions)
        {
            bonusAction.sourceCreature = this;
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
    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        OnTakeDamage?.Invoke(damage);
    }
    public abstract void Act(string action, Creature target);

    public abstract void BonusAct(string bonusAction, Creature target);
    public abstract void TickStatuses();
    public void StartTurn()
    {
        OnStartTurn?.Invoke();
        //TickStatuses();
    }

   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(Dice.dice.Roll(2,8));
            
        }
    }
}
