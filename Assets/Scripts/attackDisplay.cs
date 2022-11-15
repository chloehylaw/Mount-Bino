using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class attackDisplay : MonoBehaviour
{
    [SerializeField] public TMP_Text text;
    [SerializeField] public MeleeAttack attack;
    [SerializeField] public Fighter fighter;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TMP_Text>();
        attack = (MeleeAttack)fighter.Actions[0];
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Attack roll: " + attack.attack.ToString() + " + 7 = " + (attack.attack+7);
        if (attack.attack == 20)
            text.text += "\n Critical hit!";
    }
}
