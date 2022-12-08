using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlay : MonoBehaviour
{
    public void clickStatsButton()
    {
        GameHandler.gameHandler.EnterStatsScene();
    }
    
    public void clickMapButton()
    {
        GameHandler.gameHandler.EnterMapScene();
    }
    
}
