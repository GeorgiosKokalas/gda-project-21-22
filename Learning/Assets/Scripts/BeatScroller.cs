using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;

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

    public MidiFile mapTrack;

    // public Player Frog;

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 20f;
        rotation = leftSpawn.transform.rotation;
        generateBeatmap();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            if (Input.anyKeyDown)
            {
                hasStarted = true;
            }
        } else
        {
            foreach (Transform child in transform)
            {
                child.transform.position += child.transform.forward * beatTempo * Time.deltaTime;
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

    //CUSTOM-MADE FUNCTIONS
    void generateBeatmap()
    {
        //create array of timestamps representing each note
        //procede through array in order (should already be sorted)
        //when current time = note's time, spawn note (with an offset to account for the time to travel from spawn to the hit zone, and a grace window to allow for error), then advance through array

    }
}
