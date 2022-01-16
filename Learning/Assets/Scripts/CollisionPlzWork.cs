using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollisionPlzWork : MonoBehaviour
{
    public Text LogCollisionEnter;
    public Text LogCollisionStay;
    public Text LogCollisionExit;
    public Player Frog;

    [SerializeField] TextMeshProUGUI tmp;
    private bool hit_check = false;

    void Start()
    {
        GameObject go = GameObject.Find("Note");
        if (go)
        {
            Debug.Log(go.name);
        }
        else
        {
            Debug.Log("No game object called Indicator_note found");
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision != null)
        {
            Debug.Log("On Trigger Enter: " + collision.GetComponent<Collider>().name);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        int new_val = int.Parse(tmp.text);
        if (hit_check){
            new_val += 10;
            Frog.TakeDamage(-2f);
        } else {
            new_val -= 10;
            Frog.TakeDamage(2f);
        }
        tmp.text = new_val.ToString();
        hit_check = false;
        Destroy (other.gameObject); 
    }

    /*
    private void OnTriggerStay(Collider collision)
    {
        LogCollisionStay.text = "On Trigger stay: " + gameObject.GetComponent<Indicator_note>().name;
    }

    private void OnTriggerExit(Collider collision)
    {
        LogCollisionExit.text = "On Trigger exit: " + gameObject.GetComponent<Collider>().name;
    }
    */
}
