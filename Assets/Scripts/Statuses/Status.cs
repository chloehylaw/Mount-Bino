using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using static Dice;

public class Status : MonoBehaviour
{
    public int Duration; //in seconds
    public int TimeRemaining;
    public string StatusName;
    public Creature AffectedCreature;
    public Creature SourceCreature;
    public bool Concentration;
    public List<int> AffectedAdvantages;
    public List<DieExpression> AffectedBonuses;
    public DieExpression Effect;
    public Action AssociatedAction;
    public GameHandler.AbilityScores SavingThrow;
    public int SaveDC;
    public bool SaveEveryTurn;
    public void StartStatus()
    {
        for(int i = 0; i < AffectedAdvantages.Count; i++)
        {
            AffectedAdvantages[i] += Effect;
        }
        for(int i = 0; i < AffectedBonuses.Count; i++)
        {
            AffectedBonuses[i] += Effect;
        }
    }

    public void Tick(int s)
    {
        TimeRemaining -= s;
        if (TimeRemaining <= 0)
        {
            EndStatus();
        }
    }

    public void EndStatus()
    {
        for (int i = 0; i < AffectedAdvantages.Count; i++)
        {
            AffectedAdvantages[i] -= Effect;
        }
        for (int i = 0; i < AffectedBonuses.Count; i++)
        {
            AffectedBonuses[i] -= Effect;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        AffectedCreature = GetComponent<Creature>();
        if (SaveEveryTurn)
            AffectedCreature.OnEndTurn += SaveAtEndOfTurn;
        StartStatus();
        TimeRemaining = Duration;
    }

    public void SaveAtEndOfTurn()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
