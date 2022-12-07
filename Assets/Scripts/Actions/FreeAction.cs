using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeAction : Action
{
    void Awake()
    {
        sourceCreature = gameObject.GetComponent<Creature>();

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public override void Use(Creature target)
    {
        throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
