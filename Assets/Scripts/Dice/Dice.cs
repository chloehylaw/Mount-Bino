using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;

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
    /// <param name="amount">Must be positive, 0 returns 0</param>
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
        Debug.Log("Rolling " + amount + "d" + size + ": " + string.Join(", ", diceList) + " = " + temp);
        diceRolled.Invoke();
        //text.text += " = " + temp;
        //Invoke(nameof(EraseText), 5);
        lastSum = temp;
        return temp;
    }

    public class DieExpression : MonoBehaviour
    {
        public string Expression;
        public int[] rolls;

        public DieExpression(string expression)
        {
            rolls = new int[101];
            
            if (Regex.IsMatch(expression, "([+-]?[1-9]+([d][1-9]+)?)([+-]([1-9]+([d][1-9]+)?))*"))
            {
                var t = Regex.Matches(expression, "[+-]?[0-9]+[d][0-9]+|[+-]?[0-9]+");
                foreach (Match r in t)
                {
                    Debug.Log(r.Captures.Count + " x " + r.Value);
                    string[] a = r.Value.Split('d');
                    if (a.Length == 2)
                        rolls[int.Parse(a[1])] += int.Parse(a[0]);
                    else
                        rolls[0] += int.Parse(a[0]);
                }
            }
            else
                throw new InvalidDieExpressionException();
        }
        
        public static implicit operator DieExpression(string a) => new DieExpression(a);

        public static DieExpression operator +(DieExpression a, DieExpression b)
        {
            for(int i = 0; i < a.rolls.Length; i++)
            {
                a.rolls[i] += b.rolls[i];
            }

            return a;
        }
        public static DieExpression operator -(DieExpression a)
        {
            for (int i = 0; i < a.rolls.Length; i++)
                i = -i;

            return a;
        }

        public static DieExpression operator -(DieExpression a, DieExpression b)
        {
            for (int i = 0; i < a.rolls.Length; i++)
                a.rolls[i] -= b.rolls[i];

            return a;
        }

        public static implicit operator int(DieExpression d)
        {
            //var rolls = Regex.Matches(d.Expression, "[+-]?[0-9]+[d][0-9]+|[+-]?[0-9]+");
            //int returnal = 0;
            //foreach (string roll in rolls)
            //{
            //    bool isNegative = false;
            //    if (roll[0] == '-')
            //    {
            //        var t = roll[1..];
            //        isNegative = true;
            //    }
            //    string[] temp = roll.Split('d');
            //    if (temp.Length == 2)
            //    {
            //        if(!isNegative)
            //            returnal += dice.Roll(int.Parse(temp[0]), int.Parse(temp[1]));
            //        else
            //            returnal -= dice.Roll(int.Parse(temp[0]), int.Parse(temp[1]));
            //    }
            //    else if (!temp.Equals(""))
            //        returnal += int.Parse(temp[0]);
            //}
            //return returnal;

            int returnal = 0;
            
            for (int i = 0; i < d.rolls.Length; i++)
            {
                if (i == 0)
                    returnal += d.rolls[i];
                else
                {
                    if (d.rolls[i] > 0)
                        returnal += dice.Roll(d.rolls[i], i);
                    else if (d.rolls[i] < 0)
                        returnal -= dice.Roll(-d.rolls[i], i);
                }
            }

            return returnal;
        }

        [System.Serializable]
        private class InvalidDieExpressionException : System.Exception
        {
            public InvalidDieExpressionException()
            {
            }

            public InvalidDieExpressionException(string message) : base(message)
            {
            }

            public InvalidDieExpressionException(string message, System.Exception innerException) : base(message, innerException)
            {
            }

            protected InvalidDieExpressionException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }

    private void Update()
    {

    }
}
