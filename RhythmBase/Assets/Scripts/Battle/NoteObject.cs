using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script detects the range the notes are in when pressed
//(ex: are they close to the center when hit or not)
public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress)){
            if (canBePressed)
            {
                gameObject.SetActive(false);

                //GameManager.instance.NoteHit();

                if(Mathf.Abs(transform.position.y) > 0.25){
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                } else if (Mathf.Abs(transform.position.y) > 0.05f){
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                } else {
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, goodEffect.transform.rotation);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }
     private void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.activeSelf){
        if (other.tag == "Activator")
        {
            canBePressed = false;
            
            GameManager.instance.NoteMissed();
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
        }
    }
}
