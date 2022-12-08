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
     
        SetMaxHealth(creature.MaxHealth);
        creatureName.text = creature.Name;
        creature.OnTakeDamage += TakeDamage;
    }

    public void SetMaxHealth(int health)
    {
        
        slider.maxValue = health;
        slider.value = health;
        healthText.text = creature.CurrentHealth + "/" + creature.MaxHealth;
    }

    public void SetHealth(int health)
    {
        
        slider.value = health;
        healthText.text = creature.CurrentHealth + "/" + creature.MaxHealth;
       
    }

    public void TakeDamage(int damage)
    {
        slider.value = creature.CurrentHealth;
        healthText.text = creature.CurrentHealth + "/" + creature.MaxHealth;
       
    }
}
