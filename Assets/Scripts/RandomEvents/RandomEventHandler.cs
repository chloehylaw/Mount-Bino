using UnityEngine;
namespace RandomEvents
{
    public class RandomEventHandler : MonoBehaviour
    {
        public static RandomEventHandler eventHandler;
        
        public void Start ()
        {
            eventHandler = GetComponent<RandomEventHandler>();
        }

        public void StartEvent ()
        {
        
        }
    }
}
