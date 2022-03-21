using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawn : MonoBehaviour
{

    private GameObject target;
    private GameObject leftSpawn;
    private GameObject midSpawn;
    private GameObject rightSpawn;
    private GameObject leftCol;
    private GameObject midCol;
    private GameObject rightCol;
    public bool defensePhase = true;

    // Start is called before the first frame update
    void Start()
    {
        if (defensePhase)
        {
            leftSpawn = GameObject.Find("LeftNoteSpawn");
            midSpawn = GameObject.Find("MidNoteSpawn");
            rightSpawn = GameObject.Find("RightNoteSpawn");

            leftCol = GameObject.Find("Left_col_A");
            midCol = GameObject.Find("Mid_col_S");
            rightCol = GameObject.Find("Right_col_D");

        }
        else //we have to flip where the notes spawn from and also which lanes are right and left
        {
            leftSpawn = GameObject.Find("Right_col_D");
            midSpawn = GameObject.Find("Mid_col_S");
            rightSpawn = GameObject.Find("Left_col_A");

            leftCol = GameObject.Find("RightNoteSpawn");
            midCol = GameObject.Find("MidNoteSpawn");
            rightCol = GameObject.Find("LeftNoteSpawn");
        }

        //temporary solution while our notes are not being automatically instantiated:
        if (tag == "left_note")
        {
            target = leftCol;
            transform.LookAt(target.transform);
            transform.position = leftSpawn.transform.position;
        }
        else if (tag == "mid_note")
        {
            target = midCol;
            transform.LookAt(target.transform);
            transform.position = midSpawn.transform.position;
        }
        else if (tag == "right_note")
        {
            target = rightCol;
            transform.LookAt(target.transform);
            transform.position = rightSpawn.transform.position;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
