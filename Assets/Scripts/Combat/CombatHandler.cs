using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatHandler : MonoBehaviour
{
    public static CombatHandler combatHandler;
    public List<CreatureSlot> Friendlies;
    public List<CreatureSlot> Enemies;
    public int round;
    public List<Initiative> Initiatives = new();
    public Initiative currentInitiative;
    public List<CombatButton> CreatureUI;

    public HealthBar healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        combatHandler = GetComponent<CombatHandler>();
        
        
    }

    public void StartCombat(List<Creature> Party, List<Creature> Enemies)
    {
        
        foreach (Creature p in Party)
        {
            Friendlies[Party.IndexOf(p)].creature = p;
            CreatureUI[Party.IndexOf(p)].button.onClick.AddListener(p.EndTurn);
            p.OnStartTurn += (CreatureUI[Party.IndexOf(p)].StartTurn);

            var temp = Instantiate(healthBar, Friendlies[Party.IndexOf(p)].transform);
            temp.transform.Translate(new Vector2(0, 0));
            temp.creature = p;
        }

        foreach (Creature p in Enemies)
        {
            this.Enemies[Enemies.IndexOf(p)].creature = p;
            CreatureUI[Enemies.IndexOf(p)+4].button.onClick.AddListener(p.EndTurn);
            p.OnStartTurn  += (CreatureUI[Enemies.IndexOf(p)+4].StartTurn);
            var temp = Instantiate(healthBar, this.Enemies[Enemies.IndexOf(p)].transform);
            temp.transform.Translate(new Vector2(0, 0));
            temp.creature = p;
        }

        round = 1;
        RollInitiative();
        currentInitiative = Initiatives[0];
        currentInitiative.creature.StartTurn();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdvanceTurn()
    {
        int temp = Initiatives.IndexOf(currentInitiative);
        if(temp == Initiatives.Count - 1)
        {
            round++;
            currentInitiative = Initiatives[0];
        }
        else currentInitiative = Initiatives[temp+1];
        currentInitiative.creature.StartTurn();

    }

    public void RollInitiative()
    {
        Initiatives = new List<Initiative>() { };

        foreach (CreatureSlot c in Friendlies)
        {
            var t = gameObject.AddComponent<Initiative>();
            t.creature = c;
            t.score =
                Dice.dice.Roll(1, 20) + 
                c.creature.GetInitiativeBonus(); 
                
            Initiatives.Add(t);
        }

        foreach (CreatureSlot c in Enemies)
        {
            var t = gameObject.AddComponent<Initiative>();
            t.creature = c;
            t.score = Dice.dice.Roll(1, 20) + c.creature.GetInitiativeBonus();
            Initiatives.Add(t);
        }

        Initiatives.Sort(InitiativeSorter);

    }

    public static int InitiativeSorter(Initiative a, Initiative b)
    {
        if (a.score > b.score)
            return -1;
        else if (b.score > a.score)
            return 1;
        else 
        {
            if (a.creature.Dexterity > b.creature.Dexterity) return -1;
            else if (b.creature.Dexterity > a.creature.Dexterity) return 1;
            else if (Random.Range(0, 2) == 0) return 1;
            else return -1;
        }
    }


}