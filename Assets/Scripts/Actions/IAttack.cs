using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public interface IAttack 
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="target"></param>
    /// <param name="source"></param>
    /// <param name="AttackBonus"></param>
    /// <param name="DamageBonus"></param>
    /// <param name="DamageDiceSize"></param>
    /// <param name="DamageDiceAmount"></param>
    /// <param name="Advantage"> Positive for adv, negative for disadv</param>
    public abstract void Attack(Creature target, Creature source,
        int DamageDiceSize, int DamageDiceAmount, int DamageBonus, int AttackBonus,  int Advantage = 0);

    // Update is called once per frame
    void Update()
    {
        
    }
}
