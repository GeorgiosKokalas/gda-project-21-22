using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
Script that detects collision and affects the healthbar based on player input
Users: The collision boxes called Cube_col under Bars
*/
public class CollisionPlzWork : MonoBehaviour {
//------VARIABLES-----------------------------
    // The Player that takes the actions
    [SerializeField] HealthBar health_bar;

    [SerializeField] TextMeshProUGUI tmp;
    
    // Identifier for the type o
    [SerializeField] KeyCode CollisionKey;

    // Checks for when and if the player should hit keys 
    [SerializeField] bool hit_check = false; // Checks if the player has hit keys
    [SerializeField] bool has_note = false;  // Checks if the player needs to hit a key



//------BUILT-IN FUNCTIONS-----------------------
    private void Update(){
        CheckForPress();
    }
    
    private void OnTriggerEnter(Collider other){
        StartNoteTaking(other);
    }


    private void OnTriggerExit(Collider other){
        StopNoteTaking(other);
    }



//------CUSTOM-MADE FUNCTIONS----------------------
    // Check if the collision happened from a note
    // Make the collision box wait for Player Input
    void StartNoteTaking(Collider other){
        // Get the name for debugging purposes
        if(other != null){ Debug.Log("On Trigger Enter: " + other.GetComponent<Collider>().name);}

        /* If the collision is caused by an enemy note (as it should),
           Indicate that this collision box needs player input*/
        if(other.tag == "enemy_note"){
            has_note = true;
        }
    }


    // Check if the note exited.
    // If so, adjust score accordingly
    void StopNoteTaking(Collider other){
        /* If the collision exit is triggered by an enemy note,
           indicate that this collision box no longer needs player input */
        if(other.tag == "enemy_note"){
            has_note = false;
        }
        // based on if the player has hit the correct box, determine their new health
        int new_val = int.Parse(tmp.text);
        if (hit_check){
            new_val += 10;
            health_bar.ChangeHealth(5f); 
        } else {
            new_val -= 10;
            health_bar.ChangeHealth(-5f); 
        }
        tmp.text = new_val.ToString();
        hit_check = false;              //Revert hit_check to its original value
        Destroy (other.gameObject);     //Destroy the note that just exited
    }

    
    // Check every time a button is pressed 
    public void CheckForPress() {
        if (!Input.GetKeyDown(CollisionKey)){ return; } // Exit if any other key was pressed
        // Debug.Log("POWER");
        if (has_note){              //If there is note to hit check that the player is good
            Debug.Log("POWER");
            hit_check = true;
            has_note = false;           // Only hit it once
        } else {                    //Otherwise damage player
            health_bar.ChangeHealth(-5f); 
        }
    }















//-------- EXTRAS ----------------------------
        // I don't know why those are here
    // public Text LogCollisionEnter;
    // public Text LogCollisionStay;
    // public Text LogCollisionExit;
    


    //I don't know what this is
    // void Start() {
    //     // StartFunction()
    //     // I put the code in StartFunction(), because I didn't know what it was for
    // }
    // void StartFunction(){
    //     GameObject go = GameObject.Find("Note");
    //     if (go)
    //     {
    //         Debug.Log(go.name);
    //     }
    //     else
    //     {
    //         Debug.Log("No game object called Indicator_note found");
    //     }
    // }


    
    /*
    private void OnTriggerStay(Collider collision)
    {
        LogCollisionStay.text = "On Trigger stay: " + gameObject.GetComponent<Indicator_note>().name;
    }

    private void OnTriggerExit(Collider collision)
    {
        LogCollisionExit.text = "On Trigger exit: " + gameObject.GetComponent<Collider>().name;
    }
    */
}
