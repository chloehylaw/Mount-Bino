using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEncounter : MonoBehaviour
{
    public List<Creature> enemies;
    public static implicit operator List<Creature>(CombatEncounter A) => A.enemies;
}
