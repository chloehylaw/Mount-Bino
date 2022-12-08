using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using TMPro;

public class Display : MonoBehaviour
{
    public TMP_Text text;
    [SerializeField] Creature creature;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = creature.CurrentHealth + "/" + creature.MaxHealth;
    }
}
