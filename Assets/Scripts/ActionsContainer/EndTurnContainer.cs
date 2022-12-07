using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndTurnContainer : ActionsContainer
{
    public Creature creature;

    public List<EndTurnAction> endTurnActionsList;

    public Button actionButton;

    //public EndTurn endTurn;


    // Start is called before the first frame update
    void Start()
    {
        CombatHandler.combatHandler.OnStartTurn += Initialize;
        //actionButton = endTurn.GetComponent<Button>();
    }

    public void Initialize(Creature creature)
    {

        this.enabled = true;
        endTurnActionsList = creature.EndTurnActions;
        if (endTurnActionsList.Count <= 0)
        {
            this.enabled = false;
            var something = GetComponent<RectTransform>();
            something.sizeDelta = new Vector2(0, 0);
        }
        else
        {


            foreach (var endTurnAction in endTurnActionsList)
            {

                var tempButton = Instantiate(actionButton, transform);
                //var tempText = Instantiate(actionText);
                tempButton.GetComponentInChildren<TextMeshProUGUI>().text = endTurnAction.Name;
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
