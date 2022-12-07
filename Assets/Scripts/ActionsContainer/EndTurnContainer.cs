using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndTurnContainer : ActionsContainer
{
    public Creature creature;

    public List<BonusAction> endTurnActionsList;

    public Button endTurnActionButton;


    // Start is called before the first frame update
    void Start()
    {
        CombatHandler.combatHandler.OnStartTurn += Initialize;
    }

    public void Initialize(Creature creature)
    {
        
        endTurnActionsList = creature.EndTurnActions;

        foreach (var bonusAction in endTurnActionsList)
        {

            var tempButton = Instantiate(endTurnActionButton, transform);
            //var tempText = Instantiate(actionText);
            tempButton.GetComponentInChildren<TextMeshProUGUI>().text = bonusAction.Name;
            var something = GetComponent<RectTransform>();
            something.sizeDelta = new Vector2(something.sizeDelta.x + tempButton.GetComponent<RectTransform>().sizeDelta.x + 25, something.sizeDelta.y);
        }
        

    }
    // Update is called once per frame
    void Update()
    {

    }
}
