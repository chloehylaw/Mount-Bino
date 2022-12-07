using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BonusActionsContainer : ActionsContainer
{
    public Creature creature;

    public List<BonusAction> bonusActionsList;

    public Button actionButton;


    // Start is called before the first frame update
    void Start()
    {
        CombatHandler.combatHandler.OnStartTurn += Initialize;
    }

    public void Initialize(Creature creature)
    {
        this.enabled = true;
        
        if (bonusActionsList.Count <= 0)
        {
            this.enabled = false;
            var something = GetComponent<RectTransform>();
            something.sizeDelta = new Vector2(0, something.sizeDelta.y);
        } else
        {
            bonusActionsList = creature.BonusActions;

            foreach (var bonusAction in bonusActionsList)
            {

                var tempButton = Instantiate(actionButton, transform);
                //var tempText = Instantiate(actionText);
                tempButton.GetComponentInChildren<TextMeshProUGUI>().text = bonusAction.Name;
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