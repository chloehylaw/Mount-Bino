using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI creatureName;

    public Creature creature;
    
    private void Start()
    {

    }
    private void Update()
    {
        healthText.text = creature.CurrentHealth + "/" + creature.MaxHealth;
        creatureName.text = creature.Name;
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
