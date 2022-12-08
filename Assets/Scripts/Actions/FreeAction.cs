using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeAction : Action
{
    void Awake()
    {
        sourceCreature = gameObject.GetComponent<Creature>();

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
