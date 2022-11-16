using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler gameHandler;
    public List<Creature> Party;
    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GetComponent<GameHandler>();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
