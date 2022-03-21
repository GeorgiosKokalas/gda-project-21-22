using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPhase : MonoBehaviour
{

    public GameObject noteholder;
    public GameObject attackNote;
    public GameObject defenseNote;
    public GameObject player;
    public GameObject enemy;
    public Sprite playerBackSprite;
    public Sprite playerFrontSprite;
    public GameObject attackCamera;
    public GameObject defenseCamera;
    public GameObject attackLight;
    public GameObject defenseLight;
    public GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void swapPhase()
    {
        if (noteholder.GetComponent<BeatScroller>().notePrefab == defenseNote)
        {
            swaptoAttack();
        }
        else
        {
            swaptoDefense();
        }

    }

    public void swaptoAttack()
    {
        noteholder.GetComponent<BeatScroller>().notePrefab = attackNote;
        player.GetComponent<SpriteRenderer>().sprite = playerFrontSprite;
        //enemy.GetComponent<SpriteRenderer>().sprite = enemyFrontSprite; //we dont have enemy backsprites yet
        attackCamera.active = true;
        attackCamera.GetComponent<AudioListener>().enabled = true;
        defenseCamera.GetComponent<AudioListener>().enabled = false;
        defenseLight.active = false;
        attackLight.active = true;
        Canvas canvas = background.GetComponent<Canvas>();
        canvas.worldCamera = attackCamera.GetComponent<Camera>();

        //THESE VALUES WILL NEED TO BE MANUALLY UPDATED IF WE CHANGE THE LAYOUT AND POSITION OF THE LANES
        player.GetComponent<Transform>().position = new Vector3(-3.04f, 1.93f, -4.17f);
        player.GetComponent<Transform>().rotation = new Quaternion(-0.0230721869f, 0.0666044131f, 0.00154054316f, 0.997511506f);
        player.GetComponent<Transform>().localScale = new Vector3(0.25f, 0.25f, 1f);

        enemy.GetComponent<Transform>().position = new Vector3(0.959999979f, 0.910000026f, 6.63999987f);
        enemy.GetComponent<Transform>().rotation = new Quaternion(-0.124073341f, -0.298288763f, 0.0536679998f, 0.94485414f);
        enemy.GetComponent<Transform>().localScale = new Vector3(0.280000001f, 0.280000001f, 1f);

        //background.GetComponent<Canvas>().renderMode.ScreenSpaceCamera = attackCamera;
        //attackCamera.worldCamera = attackCamera;


    }

    public void swaptoDefense()
    {
        noteholder.GetComponent<BeatScroller>().notePrefab = defenseNote;
        player.GetComponent<SpriteRenderer>().sprite = playerBackSprite;
        //enemy.GetComponent<SpriteRenderer>().sprite = enemyBackSprite; //we dont have enemy backsprites yet
        attackCamera.active = false;
        attackCamera.GetComponent<AudioListener>().enabled = false;
        defenseCamera.GetComponent<AudioListener>().enabled = true;
        attackLight.active = true;
        defenseLight.active = true;
        Canvas canvas = background.GetComponent<Canvas>();
        canvas.worldCamera = defenseCamera.GetComponent<Camera>();

        //THESE VALUES WILL NEED TO BE MANUALLY UPDATED IF WE CHANGE THE LAYOUT AND POSITION OF THE LANES
        player.GetComponent<Transform>().position = new Vector3(-2.46f, 1.38f, -5.5f);
        player.GetComponent<Transform>().rotation = new Quaternion(0.126078591f, -0.256604791f, 0.0337826498f, 0.957662225f);
        player.GetComponent<Transform>().localScale = new Vector3(0.17f, 0.17f, 1f);

        enemy.GetComponent<Transform>().position = new Vector3(-1.57f, 1.24f, 11.6f);
        enemy.GetComponent<Transform>().rotation = new Quaternion(0.126078591f, -0.256604791f, 0.0337826498f, 0.957662225f);
        enemy.GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 1f);

        //background.GetComponent<Canvas>().renderMode.ScreenSpaceCamera = defenseCamera;

    }

}
