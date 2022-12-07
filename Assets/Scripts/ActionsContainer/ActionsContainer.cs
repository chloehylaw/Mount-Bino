using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsContainer : MonoBehaviour
{
    public CombatHandler combatHandler;
    
    public List<ActionsContainer> actionsContainer;

    public float width;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Ligma());
        // subscribe to event in combat handler 
        // public event Action<Creature> OnStartTurn -> in combat handler
        
    }

    public IEnumerator Ligma()
    {
        yield return new WaitForEndOfFrame();
        Initialize();
    }

    public void Initialize()
    {
        actionsContainer = new List<ActionsContainer>(GetComponentsInChildren<ActionsContainer>());
        width = 0;
        foreach (var a in actionsContainer)
        {
            if (a != this)
            {
                width += a.GetComponent<RectTransform>().sizeDelta.x + 25;
            }

        }
        GetComponent<RectTransform>().sizeDelta = new Vector2(width, GetComponent<RectTransform>().sizeDelta.y);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
