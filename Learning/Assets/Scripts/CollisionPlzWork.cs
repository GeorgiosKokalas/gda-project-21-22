using UnityEngine;
using UnityEngine.UI;

public class CollisionPlzWork : MonoBehaviour
{
    public Text LogCollisionEnter;
    public Text LogCollisionStay;
    public Text LogCollisionExit;

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
