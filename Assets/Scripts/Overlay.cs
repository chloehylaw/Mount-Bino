using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlay : MonoBehaviour
{
    public GameObject Stats;
    private bool enteredStats;
    public void clickStatsButton()
    {
        if (enteredStats == false)
        {
            Stats.SetActive(true);
            enteredStats = true;
        } else
        {
            Stats.SetActive(false);
            enteredStats = false;
        }
       
    }

    
}
