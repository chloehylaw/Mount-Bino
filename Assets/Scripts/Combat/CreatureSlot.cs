using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CreatureSlot : MonoBehaviour
{
    public Creature creature;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static implicit operator Creature(CreatureSlot c) => c.creature;

    // Update is called once per frame
    void Update()
    {
        
    }
}
