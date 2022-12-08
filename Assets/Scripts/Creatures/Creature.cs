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

    public bool IsProficientStrengthSaves;
    public bool IsProficientDexteritySaves;
    public bool IsProficientConstitutionSaves;
    public bool IsProficientIntelligenceSaves;
    public bool IsProficientWisdomSaves;
    public bool IsProficientCharismaSaves;

    public int ArmorClass;
    public string Name;
    public int MaxHealth;
    public int CurrentHealth;
    public int ProficiencyBonus;
    public List<Action> Actions;
    public List<BonusAction> BonusActions;
    public List<FreeAction> FreeActions;
    public List<EndTurnAction> EndTurnActions;
    public List<Spell> Spells;
    public List<Status> Statuses;
    public Weapon EquippedWeapon;
    public event System.Action OnStartTurn;
    public event System.Action OnEndTurn;
    public event System.Action<int> OnTakeDamage;

    public int StatusEffectStrengthCheckAdvantage = 0;
    public int StatusEffectDexterityCheckAdvantage = 0;
    public int StatusEffectConstitutionCheckAdvantage = 0;
    public int StatusEffectIntelligenceCheckAdvantage = 0;
    public int StatusEffectWisdomCheckAdvantage = 0;
    public int StatusEffectCharismaCheckAdvantage = 0;
    public int StatusEffectStrengthSaveAdvantage = 0;
    public int StatusEffectDexteritySaveAdvantage = 0;
    public int StatusEffectConstitutionSaveAdvantage = 0;
    public int StatusEffectIntelligenceSaveAdvantage = 0;
    public int StatusEffectWisdomSaveAdvantage = 0;
    public int StatusEffectCharismaSaveAdvantage = 0;
    public int StatusEffectCheckAdvantage = 0;
    public int StatusEffectAttackAdvantage = 0;
    public int StatusEffectSaveAdvantage = 0;
    public int StatusEffectAttackAgainstAdvantage;
    public DieExpression StatusEffectCheckBonus;
    public DieExpression StatusEffectAttackBonus;
    public DieExpression StatusEffectSaveBonus;
    public DieExpression StatusEffectACBonus;
    public DieExpression StatusEffectDamageBonus;


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
        foreach (var freeAction in FreeActions)
        {
            freeAction.sourceCreature = this;
        }
        foreach (var endTurnAction in EndTurnActions)
        {
            endTurnAction.sourceCreature = this;
        }
    }
    public int GetArmorClass()
    {
        return ArmorClass + StatusEffectACBonus;
    }
    public abstract void Die();
    public abstract void EnterDying();
    public void EndTurn()
    {
        OnEndTurn?.Invoke();
    }
    public int GetAttackBonus()
    {
        if (EquippedWeapon.UsesDex && EquippedWeapon.UsesStrength)
            return Mathf.Max(Dexterity, Strength) + StatusEffectAttackBonus;
        else if (EquippedWeapon.UsesDex)
            return Dexterity + StatusEffectAttackBonus;
        else
            return Strength + StatusEffectAttackBonus;
    }
    public abstract int GetDamageBonus();
    internal Weapon GetWeapon()
    {
        return EquippedWeapon;
    }

    internal int GetInitiativeBonus()
    {
        return Dexterity;
    }
    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        OnTakeDamage?.Invoke(damage);
    }

    public virtual void ShortRest()
    {
        // half max hp when doing short rest
        TakeDamage((MaxHealth / 2)*(-1));
    }
    public abstract void Act(string action, Creature target);
    public void TickStatuses(int s)
    {
        foreach(var status in Statuses)
        {
            status.Tick(s);
        }
    }
    public abstract void BonusAct(string bonusAction, Creature target);
    public abstract void FreeAct(string bonusAction, Creature target);
    public abstract void EndTurnAct(string bonusAction, Creature target);
    public void StartTurn()
    {
        OnStartTurn?.Invoke();
        //TickStatuses();
    }

    public int GetSpellSaveDC()
    {
        return 8 + Intelligence + ProficiencyBonus;
    }

    public int MakeStrengthSave() 
    {
        return Dice.dice.Roll(1, 20, StatusEffectStrengthSaveAdvantage + StatusEffectSaveAdvantage) + Strength + (IsProficientStrengthSaves ? 3 : 0) + StatusEffectSaveBonus;
    }

    public int MakeDexteritySave()
    {
        return Dice.dice.Roll(1, 20, StatusEffectDexteritySaveAdvantage + StatusEffectSaveAdvantage) + Dexterity + (IsProficientDexteritySaves ? 3 : 0) + StatusEffectSaveBonus;
    }

    public int MakeConstituionSave()
    {
        return Dice.dice.Roll(1, 20, StatusEffectConstitutionSaveAdvantage + StatusEffectSaveAdvantage) + Constitution + (IsProficientConstitutionSaves ? 3 : 0) + StatusEffectSaveBonus;
    }

    public int MakeIntelligenceSave()
    {
        return Dice.dice.Roll(1, 20, StatusEffectIntelligenceSaveAdvantage + StatusEffectSaveAdvantage) + Intelligence + (IsProficientIntelligenceSaves ? 3 : 0) + StatusEffectSaveBonus;
    }

    public int MakeWisdomSave()
    {
        return Dice.dice.Roll(1, 20, StatusEffectWisdomSaveAdvantage + StatusEffectSaveAdvantage) + Wisdom + (IsProficientWisdomSaves ? 3 : 0) + StatusEffectSaveBonus;
    }

    public int MakeCharismaSave()
    {
        return Dice.dice.Roll(1, 20, StatusEffectCharismaSaveAdvantage + StatusEffectSaveAdvantage) + Charisma + (IsProficientCharismaSaves ? 3 : 0) + StatusEffectSaveBonus;
    }

    public int MakeStrengthCheck() 
    { 
        return Dice.dice.Roll(1, 20, StatusEffectStrengthCheckAdvantage + StatusEffectCheckAdvantage) + Strength + StatusEffectCheckBonus;
    }

    public int MakeDexterityCheck()
    {
        return Dice.dice.Roll(1, 20, StatusEffectDexterityCheckAdvantage + StatusEffectCheckAdvantage) + Dexterity + StatusEffectCheckBonus;
    }

    public int MakeConstitutionCheck()
    {
        return Dice.dice.Roll(1, 20, StatusEffectConstitutionCheckAdvantage + StatusEffectCheckAdvantage) + Constitution + StatusEffectCheckBonus;
    }

    public int MakeIntelligenceCheck()
    {
        return Dice.dice.Roll(1, 20, StatusEffectIntelligenceCheckAdvantage + StatusEffectCheckAdvantage) + Intelligence + StatusEffectCheckBonus;
    }

    public int MakeWisdomCheck()
    {
        return Dice.dice.Roll(1, 20, StatusEffectWisdomCheckAdvantage + StatusEffectCheckAdvantage) + Wisdom + StatusEffectCheckBonus;
    }

    public int MakeCharismaCheck()
    {
        return Dice.dice.Roll(1, 20, StatusEffectCharismaCheckAdvantage + StatusEffectCheckAdvantage) + Charisma + StatusEffectCheckBonus;
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
