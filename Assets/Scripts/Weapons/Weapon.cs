using System.Collections;
using System.Collections.Generic;
using Creatures;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int DamageDiceSize;
    public int DamageDiceAmount;
    public int AttackBonus;
    public int DamageBonus;
    /// <summary>
    /// Most melee weapons only use strength
    /// </summary>
    public bool UsesStrength;
    /// <summary>
    /// Typically for ranged attacks and finesse weapons
    /// </summary>
    public bool UsesDex;
    /// <summary>
    /// This is a ranged weapon, meaning it has disadvantage in melee ranges if we implement this
    /// </summary>
    public bool IsRanged;
    /// <summary>
    /// Available targets for attack
    /// </summary>
    public List<int> Targets;
    /// <summary>
    /// Positions from which the weapon can attack
    /// </summary>
    public List<int> Positions;
    public Creature Wielder;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
