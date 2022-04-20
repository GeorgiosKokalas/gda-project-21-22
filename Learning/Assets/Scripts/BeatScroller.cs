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
<<<<<<< Updated upstream
=======


        //BEATMAP CONTROLS
        //procede through array in order (should already be sorted)
        //when current time = note's time, spawn note (with an offset to account for the time to travel from spawn to the hit zone, and a grace window to allow for error), then advance through array
        if (Mathf.Abs((float)(Time.timeSinceLevelLoadAsDouble - noteTimestamps[currentNote])) < 0.01f)
        {
            Debug.Log("Note spawn");
            int xcount = Random.Range(1, 4);

            if (xcount == 1)
            {
                GameObject newNote = Instantiate(notePrefab, new Vector3(leftSpawn.transform.position.x, leftSpawn.transform.position.y, leftSpawn.transform.position.z), rotation, transform);
                newNote.tag = "left_note";
            }
            if (xcount == 2)
            {
                GameObject newNote = Instantiate(notePrefab, new Vector3(midSpawn.transform.position.x, midSpawn.transform.position.y, midSpawn.transform.position.z), rotation, transform);
                newNote.tag = "mid_note";
            }
            if (xcount == 3)
            {
                GameObject newNote = Instantiate(notePrefab, new Vector3(rightSpawn.transform.position.x, rightSpawn.transform.position.y, rightSpawn.transform.position.z), rotation, transform);
                newNote.tag = "right_note";
            }


            currentNote += 1;
        }

    }

    //CUSTOM-MADE FUNCTIONS
    void generateBeatmap()
    {
        //create array of timestamps representing each note
        var notes = mapTrack.GetNotes();
        TempoMap tempoMap = mapTrack.GetTempoMap();

        foreach (Melanchall.DryWetMidi.Interaction.Note item in notes)
        {
            noteTimestamps.Add(item.TimeAs<MetricTimeSpan>(tempoMap).TotalSeconds);
        }
        Debug.Log("timestamps complete");
        Debug.Log(noteTimestamps[0]);
        Debug.Log(noteTimestamps[1]);
        Debug.Log(noteTimestamps[2]);
>>>>>>> Stashed changes
    }
}
