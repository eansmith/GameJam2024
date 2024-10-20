using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float health = 100;
    public bool isHoldingChild = false;
    public Slider healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReduceHealth(float amount)
    {

        health -= amount;
        healthBar.value = health/100;
    }

    public float GetHealth(){
        return health; 
    }
}
    