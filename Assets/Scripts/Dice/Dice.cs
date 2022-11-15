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
    public int Roll(int amount, int size)
    {
        int temp = 0;
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
