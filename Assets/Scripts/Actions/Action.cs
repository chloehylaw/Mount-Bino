using System.Collections;
using System.Collections.Generic;
using Creatures;
using UnityEngine;
using UnityEngine.UI;

public abstract class Action : MonoBehaviour
{
    [SerializeField] public Creature sourceCreature;
    [SerializeField] public List<int> targetPositions;
    [SerializeField] public List<int> sourcePositions;
    [SerializeField] public bool TargetsAllies;
    public string Name;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        sourceCreature = gameObject.GetComponent<Creature>();
        button = gameObject.GetComponent<Button>();
    }

    public abstract void Use();

    // Update is called once per frame
    void Update()
    {
        
    }
}
