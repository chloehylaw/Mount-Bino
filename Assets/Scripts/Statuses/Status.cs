using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Status : MonoBehaviour
{
    public int Duration; //in seconds
    public int CurrentTime;
    public string StatusName;
    public List<Creature> AffectedCreature;
    public Creature SourceCreature;
    public bool Concentration;


    public abstract void Tick();
    public abstract void EndStatus();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
