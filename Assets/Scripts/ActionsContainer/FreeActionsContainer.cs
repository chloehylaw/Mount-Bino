using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FreeActionsContainer : ActionsContainer
{
    public Creature creature;

    public List<BonusAction> freeActionsList;

    public Button freeActionButton;


    // Start is called before the first frame update
    void Start()
    {
        CombatHandler.combatHandler.OnStartTurn += Initialize;
    }

    public void Initialize(Creature creature)
    {
        this.enabled = true;

        if (freeActionsList.Count <= 0)
        {
            this.enabled = false;
            var something = GetComponent<RectTransform>();
            something.sizeDelta = new Vector2(0, something.sizeDelta.y);
        }
        else
        {
            freeActionsList = creature.FreeActions;

            foreach (var bonusAction in freeActionsList)
            {

                var tempButton = Instantiate(freeActionButton, transform);
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
