using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    [SerializeField] public List<Status> Statuses;
    public UnityEvent m_onStartTurn;

    // Start is called before the first frame update
    void Start()
    {
        if (m_onStartTurn == null)
            m_onStartTurn = new UnityEvent();
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
    internal abstract int GetInitiativeBonus();
    public abstract void TakeDamage(int damage);
    public abstract void Act(string action, Creature target);
    public abstract void TickStatuses();
    public void StartTurn()
    {
        m_onStartTurn.Invoke();
        //TickStatuses();
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
