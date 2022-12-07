using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    protected Creature sourceCreature;
    public int Level;
    public int Cost;
    public int Duration;
    public List<int> Positions;
    public List<int> Targets;
    public int AmountOfTargets;
    // Start is called before the first frame update
    void Start()
    {
        sourceCreature = GetComponent<Creature>();
    }


    public abstract void Cast(List<Creature> targets);


    // Update is called once per frame
    void Update()
    {
        
    }
}
