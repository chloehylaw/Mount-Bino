using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour
{
    [SerializeField] public Creature sourceCreature;
    [SerializeField] public List<int> targetPositions;
    [SerializeField] public List<int> sourcePositions;
    [SerializeField] public bool TargetsAllies;


    void Awake()
    {
        sourceCreature = gameObject.GetComponent<Creature>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public abstract void Use(Creature target);

    // Update is called once per frame
    void Update()
    {
        
    }
}
