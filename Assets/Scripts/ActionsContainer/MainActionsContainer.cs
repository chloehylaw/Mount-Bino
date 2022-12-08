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
        GetComponent<RectTransform>().sizeDelta = new Vector2(0, GetComponent<RectTransform>().sizeDelta.y);

        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        Debug.Log("MaintActionsContainer invoked");
        this.enabled = true;
        actionsList = creature.Actions;
        if (actionsList.Count <= 0)
        {
            this.enabled = false;
            var something = GetComponent<RectTransform>();
            something.sizeDelta = new Vector2(0, 0);
        }
        else
        {
            

            foreach (var action in actionsList)
            {
                var tempButton = Instantiate(actionButton, transform);
                var taction = Instantiate(action, tempButton.transform);
                taction.gameObject.SetActive(true);
                taction.sourceCreature = creature;
                //var tempText = Instantiate(actionText);
                tempButton.GetComponentInChildren<TextMeshProUGUI>().text = taction.Name;
                tempButton.GetComponent<Button>().onClick.AddListener(taction.Use);
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
