using System;
using System.Collections.Generic;
using UnityEngine;
namespace RandomEvents
{
    public class RandomEventHandler : MonoBehaviour
    {
        public static RandomEventHandler randomEventHandler;
        
  
        public void Start ()
        {
            randomEventHandler = GetComponent<RandomEventHandler>();
        }

        public void StartEvent (String eventPath)
        {
            Instantiate(Resources.Load(eventPath));
        }
    }
}
