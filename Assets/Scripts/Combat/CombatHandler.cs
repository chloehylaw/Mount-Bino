using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using static Dice;

public class CombatHandler : MonoBehaviour
{
    public static CombatHandler combatHandler;
    public List<CreatureSlot> Friendlies;
    public List<CreatureSlot> Enemies;
    public int round;
    public List<Initiative> Initiatives = new();
    public Initiative currentInitiative;
    public List<CombatButton> CreatureUI;
    public DieExpression dieExpression;
    public int ticker = 0;

    public List<Creature> EnemyPositions;

    public List<Creature> FriendlyPositions;


    public HealthBar healthBar;

    public event System.Action<Creature> OnStartTurn;
    
    // Start is called before the first frame update
    void Awake()
    {
        combatHandler = GetComponent<CombatHandler>();
        
        
    }

    public void StartCombat(List<Creature> Party, List<Creature> Enemies)
    {
        EnemyPositions = Enemies;
        FriendlyPositions = Party;
        foreach (Creature p in Party)
        {
            Friendlies[Party.IndexOf(p)].creature = Instantiate(p);
            Friendlies[Party.IndexOf(p)].creature.gameObject.transform.position = Friendlies[Party.IndexOf(p)].transform.position;
            Friendlies[Party.IndexOf(p)].gameObject.SetActive(true);
            //CreatureUI[Party.IndexOf(p)].button.onClick.AddListener(Friendlies[Party.IndexOf(p)].creature.EndTurn);
            //Friendlies[Party.IndexOf(p)].creature.OnStartTurn += (CreatureUI[Party.IndexOf(p)].StartTurn);
            Friendlies[Party.IndexOf(p)].creature.OnEndTurn += AdvanceTurn;
            Friendlies[Party.IndexOf(p)].creature.GetComponent<SpriteRenderer>().enabled = true;
            Friendlies[Party.IndexOf(p)].creature.transform.localScale = new Vector3(0.3f,0.3f,1);
            var temp = Instantiate(healthBar, Friendlies[Party.IndexOf(p)].transform);
            temp.transform.Translate(new Vector2(0, 0));
            temp.creature = p;
        }
        foreach (Creature p in Enemies)
        {
            this.Enemies[Enemies.IndexOf(p)].creature = Instantiate(p);
            this.Enemies[Enemies.IndexOf(p)].creature.gameObject.transform.position = this.Enemies[Enemies.IndexOf(p)].transform.position;
            this.Enemies[Enemies.IndexOf(p)].gameObject.SetActive(true);
            //CreatureUI[Enemies.IndexOf(p)+4].button.onClick.AddListener(this.Enemies[Enemies.IndexOf(p)].creature.EndTurn);
            //this.Enemies[Enemies.IndexOf(p)].creature.OnStartTurn  += (CreatureUI[Enemies.IndexOf(p)+4].StartTurn);
            this.Enemies[Enemies.IndexOf(p)].creature.OnEndTurn += AdvanceTurn;
            this.Enemies[Enemies.IndexOf(p)].creature.GetComponent<SpriteRenderer>().enabled = true;
            this.Enemies[Enemies.IndexOf(p)].creature.transform.localScale = new Vector3(0.3f, 0.3f, 1);
            var temp = Instantiate(healthBar, this.Enemies[Enemies.IndexOf(p)].transform);
            temp.transform.Translate(new Vector2(0, 0));
            temp.creature = p;
        }


        round = 1;
        RollInitiative();
        currentInitiative = Initiatives[0];
        currentInitiative.creature.StartTurn();
        OnStartTurn.Invoke(currentInitiative.creature);
    }

    // Update is called once per frame

    public void AdvanceTurn()
    {
        Debug.Log("Starting turn for " + currentInitiative.creature.Name);
        int temp = Initiatives.IndexOf(currentInitiative);
        if(temp == Initiatives.Count - 1)
        {
            round++;
            currentInitiative = Initiatives[0];
        }
        else currentInitiative = Initiatives[temp+1];
        currentInitiative.creature.StartTurn();
        OnStartTurn.Invoke(currentInitiative.creature);
    }

    public void RollInitiative()
    {
        Initiatives = new List<Initiative>() { };

        foreach (CreatureSlot c in Friendlies)
        {
            if (c.gameObject.activeSelf)
            {

                var t = gameObject.AddComponent<Initiative>();
                t.creature = c;
                t.score =
                    Dice.dice.Roll(1, 20) + 
                    c.creature.GetInitiativeBonus(); 
                
                Initiatives.Add(t);
            }
        }

        foreach (CreatureSlot c in Enemies)
        {
            if (c.gameObject.activeSelf)
            {
                var t = gameObject.AddComponent<Initiative>();
                t.creature = c;
                t.score = Dice.dice.Roll(1, 20) + c.creature.GetInitiativeBonus();
                Initiatives.Add(t);
            }
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
