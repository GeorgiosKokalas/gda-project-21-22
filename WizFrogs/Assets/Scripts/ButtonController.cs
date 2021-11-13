using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;     // button when not pressed
    public Sprite pressedImage;     // button when pressed

    public KeyCode keyToPress;      // reacts to button press

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))    // updates image for when button is pressed
        {
            theSR.sprite = pressedImage;
        }

        if(Input.GetKeyUp(keyToPress))      // updates image for when button is not pressed
        {
            theSR.sprite = defaultImage;
        }
    }
}
