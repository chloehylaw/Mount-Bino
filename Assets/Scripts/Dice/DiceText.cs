using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceText : MonoBehaviour
{
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TMP_Text>();
    }

    public void DisplayText()
    {
        CancelInvoke();
        text.text = $"Rolling {Dice.dice.lastAmount}d{Dice.dice.lastSize}: ";
        foreach (int i in Dice.dice.diceList)
        {
            text.text += $"{i} ";
        }
        text.text += $"= {Dice.dice.lastSum}";
        Invoke(nameof(ClearText), 5);
    }

    public void ClearText()
    {
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
