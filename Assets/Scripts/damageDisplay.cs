using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class damageDisplay : MonoBehaviour
{
    [SerializeField] public TMP_Text text;
    [SerializeField] public WeaponAttack attack;
    [SerializeField] public Fighter fighter;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TMP_Text>();
        attack = (WeaponAttack)fighter.Actions[0];
    }

    // Update is called once per frame
    void Update()
    {
        //if(attack.damage > 0)
        //    text.text = "Damage roll: " + attack.damage.ToString() + " + 6 = " + (attack.damage + 6);
        //else
        //{
        //    text.text = "Miss";
        //}
    }
}
