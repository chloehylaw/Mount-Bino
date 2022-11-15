using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Status : MonoBehaviour
{
    public int duration; //in seconds
    public int currentTime;
    public string statusName;

    public abstract void Tick();
    public abstract void EndStatus();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
