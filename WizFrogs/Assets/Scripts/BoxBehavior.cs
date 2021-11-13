using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoxBehavior : MonoBehaviour
{
    private bool hit_check = false;
    [SerializeField] KeyCode key;
    [SerializeField] TextMeshProUGUI tmp;
    
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(key)){
            hit_check = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        Debug.Log("Dopa");
        int new_val = int.Parse(tmp.text);
        if (hit_check) {
            new_val += 10;
        } else {
            new_val -= 10; 
        }
        hit_check = false;
        tmp.text = new_val.ToString();
    }
}


