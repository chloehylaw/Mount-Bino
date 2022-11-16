using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initiative : MonoBehaviour
{
    public int score = 1;
    public Creature creature;

    private void Awake()
    {
    }

    public void SetScore(int s)
    {
        score = s;
    }
}
