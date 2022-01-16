using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;

    public bool hasStarted;

    public Player Frog;

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 20f;    
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
            Frog.TakeDamage(0.01f);
            transform.position -= new Vector3(0f, 0f, beatTempo * Time.deltaTime);
        }
    }
}
