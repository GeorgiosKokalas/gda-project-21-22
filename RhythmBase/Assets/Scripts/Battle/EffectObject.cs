using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script kills objects with it after they expire
public class EffectObject : MonoBehaviour
{

    public float lifetime = 1;
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
