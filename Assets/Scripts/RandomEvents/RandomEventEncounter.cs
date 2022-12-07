using UnityEngine;
using System.Collections.Generic;
namespace RandomEvents
{
    public class RandomEventEncounter : MonoBehaviour
    {
        public RandomEvent events;
        public static implicit operator RandomEvent (RandomEventEncounter A) => A.events;
    }
}
