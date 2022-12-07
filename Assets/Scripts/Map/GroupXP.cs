using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GroupXP : MonoBehaviour
{
    private TextMeshProUGUI groupXP;
    public static int groupXPValue;
    
    void Start()
    {
        groupXP = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        groupXP.text = "XP " + groupXPValue + "/14000";
    }
}
