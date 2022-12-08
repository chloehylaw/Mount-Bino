using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace RandomEvents
{
    public class RandomEventHandler : MonoBehaviour
    {
        public static RandomEventHandler randomEventHandler;
        public GameObject currentRandomEvent;
        public void Start ()
        {
            randomEventHandler = GetComponent<RandomEventHandler>();
        }

        public void StartEvent (string eventPath)
        {
            Debug.Log(eventPath);
            currentRandomEvent = (GameObject) Instantiate(Resources.Load(eventPath));
        }
    }
}
