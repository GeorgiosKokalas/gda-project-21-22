using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawn : MonoBehaviour
{

    private GameObject target;
    public GameObject leftSpawn;
    public GameObject midSpawn;
    public GameObject rightSpawn;
    public GameObject leftCol;
    public GameObject midCol;
    public GameObject rightCol;

    // Start is called before the first frame update
    void Start()
    {
        leftSpawn = GameObject.Find("LeftNoteSpawn");
        midSpawn = GameObject.Find("MidNoteSpawn");
        rightSpawn = GameObject.Find("RightNoteSpawn");

        leftCol = GameObject.Find("Left_col_A");
        midCol = GameObject.Find("Mid_col_S");
        rightCol = GameObject.Find("Right_col_D");

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
