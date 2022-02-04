using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
//------VARIABLES-----------------------------
    // I don't know what those are for
    public float destination = 0;
    public float journey = 0; 
    public float timeFlow = 0;

    // Grab Other Objects
    [SerializeField] Image fill;
    
    //Health Stats
    public float maxHealth;
    public float startingHealth;
    public float currentHealth;



//------BUILT-IN FUNCTIONS-----------------------
    private void Awake(){
        SetStartingHealth();
    }



//------CUSTOM-MADE FUNCTIONS----------------------
    //Self-Explanatory
    void SetStartingHealth(){
        gameObject.GetComponent<Slider>().maxValue = maxHealth;
        gameObject.GetComponent<Slider>().value = startingHealth;
    }

    // Takes Away or Gives Health
    public void ChangeHealth(float health_dif) {
        currentHealth += health_dif; 
        gameObject.GetComponent<Slider>().value = currentHealth;
        if (health_dif < 0)Debug.Log("DAMAGE");
    }
  
}
