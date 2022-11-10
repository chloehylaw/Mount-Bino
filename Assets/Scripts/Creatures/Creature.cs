using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    [SerializeField] public int Strength;
    [SerializeField] public int Dexterity;
    [SerializeField] public int Constitution;
    [SerializeField] public int Intelligence;
    [SerializeField] public int Wisdom;
    [SerializeField] public int Charisma;
    [SerializeField] public int ArmorClass;
    [SerializeField] public string Name;
    [SerializeField] public int MaxHealth;
    [SerializeField] public int CurrentHealth;
    [SerializeField] public int ProficiencyBonus;
    [SerializeField] public List<Action> Actions;
    [SerializeField] public List<Spell> Spells;

    // Start is called before the first frame update
    void Start()
    {
        foreach(var action in Actions)
        {
            action.sourceCreature = this;
        }
    }
    public abstract int GetArmorClass();

    public abstract int GetAttackBonus();
    public abstract int GetDamageBonus();
    public abstract void TakeDamage(int damage);
    public abstract void Act(string action, Creature target);

    // Update is called once per frame
    void Update()
    {
        
    }
}
