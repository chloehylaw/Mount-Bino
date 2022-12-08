using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//namespace RestScene
//{
    public class RestSceneHandler : MonoBehaviour
    {
        public static RestSceneHandler restSceneHandler;
    // Start is called before the first frame update
    void Start()
    {
        restSceneHandler = GetComponent<RestSceneHandler>();
    }

    void Awake()
        {
        
        StartRest();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void StartRest()
        {
            Debug.Log("Resting");
            GameHandler.gameHandler.Fighter.ShortRest();
            GameHandler.gameHandler.Cleric.ShortRest();
            GameHandler.gameHandler.Rogue.ShortRest();
            GameHandler.gameHandler.Wizard.ShortRest();
        }
    }
//}

