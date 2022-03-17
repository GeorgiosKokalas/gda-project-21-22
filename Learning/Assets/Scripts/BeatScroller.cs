using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;

    public bool hasStarted;

    public GameObject notePrefab;

    private GameObject target;

    public GameObject leftSpawn;
    public GameObject midSpawn;
    public GameObject rightSpawn;

    public GameObject leftCol;
    public GameObject midCol;
    public GameObject rightCol;

    private Quaternion rotation; 

    // public Player Frog;

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 20f;
        rotation = leftSpawn.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            if(Input.anyKeyDown)
            {
                hasStarted = true;
            }
        } else
        {
            foreach(Transform child in transform)
            {
                child.transform.position += child.transform.forward *  beatTempo * Time.deltaTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject newNote = Instantiate(notePrefab, new Vector3(leftSpawn.transform.position.x, leftSpawn.transform.position.y, leftSpawn.transform.position.z), rotation, transform);
            newNote.tag = "left_note";
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            GameObject newNote = Instantiate(notePrefab, new Vector3(midSpawn.transform.position.x, midSpawn.transform.position.y, midSpawn.transform.position.z), rotation, transform);
            newNote.tag = "mid_note";
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject newNote = Instantiate(notePrefab, new Vector3(rightSpawn.transform.position.x, rightSpawn.transform.position.y, rightSpawn.transform.position.z), rotation, transform);
            newNote.tag = "right_note";
        }
    }
}
