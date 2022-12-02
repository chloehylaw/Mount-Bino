using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Dice : MonoBehaviour
{
    public static Dice dice;
    public List<int> diceList = new();
    public int lastAmount;
    public int lastSize;
    public int lastSum;
    public UnityEvent diceRolled;

    private void Start()
    {
        dice = gameObject.GetComponent<Dice>();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="size"></param>
    /// <param name="adv"> Optional, positive for advantage, negative for disadvantage</param>
    /// <returns></returns>
    public int Roll(int amount, int size, int adv = 0) 
    {
        int temp = 0;
        int advTemp = 0;
        lastAmount = amount;
        lastSize = size;
        diceList.Clear();
        //text.text = "Rolling " + amount + "d" + size + ": ";

        for(int i = 0; i < amount; i++)
        {
            int t = Random.Range(1, size + 1);
            diceList.Add(t);
            temp += t;
            //text.text += t + " ";
        }

        if (adv != 0)
        {
            int t = Random.Range(1, size + 1);
            diceList.Add(t);
            advTemp += t;
        }

        if (adv > 0)
            temp = Mathf.Max(temp, advTemp);
        else if (adv < 0)
            temp = Mathf.Min(temp, advTemp);
        Debug.Log(temp);
        diceRolled.Invoke();
        //text.text += " = " + temp;
        //Invoke(nameof(EraseText), 5);
        lastSum = temp;
        return temp;
    }

    private void Update()
    {

    }
}
