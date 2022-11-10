using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Dice
{
    public static int Roll(int amount, int size)
    {
        int temp = 0;

        for(int i = 0; i < amount; i++)
        {
            temp += Random.Range(1, size+1);
        }
        Debug.Log(temp);
        return temp;
    }
}
