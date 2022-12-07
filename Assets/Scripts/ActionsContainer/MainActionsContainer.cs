using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainActionsContainer : ActionsContainer
{
    public Creature creature;

    public List<Action> actionsList;

    public Button actionButton;


    
    // Start is called before the first frame update
    void Start()
    {
        CombatHandler.combatHandler.OnStartTurn += Initialize;

        
    }

    public void Initialize(Creature creature)
    {
        this.enabled = true;
        actionsList = creature.Actions;
        if (actionsList.Count <= 0)
        {
            this.enabled = false;
            var something = GetComponent<RectTransform>();
            something.sizeDelta = new Vector2(0, something.sizeDelta.y);
        }
        else
        {
            

            foreach (var action in actionsList)
            {

                var tempButton = Instantiate(actionButton, transform);
                //var tempText = Instantiate(actionText);
                tempButton.GetComponentInChildren<TextMeshProUGUI>().text = action.Name;
                var something = GetComponent<RectTransform>();
                something.sizeDelta = new Vector2(something.sizeDelta.x + tempButton.GetComponent<RectTransform>().sizeDelta.x + 25, something.sizeDelta.y);

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
