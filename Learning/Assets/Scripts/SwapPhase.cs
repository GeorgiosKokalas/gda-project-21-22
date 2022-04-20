using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SwapPhase : MonoBehaviour
{

    public GameObject noteholder;
    public GameObject attackNote;
    public GameObject defenseNote;
    public GameObject player;
    public GameObject enemy;
    public Sprite playerBackSprite;
    public Sprite playerFrontSprite;
    public GameObject attackSwapControlPanel;
    public GameObject defenseSwapControlPanel;
    private PlayableDirector director;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //example phase swaps at random time intervals, will change later
      /*if (Mathf.Abs((float)(Time.timeSinceLevelLoad - 5f)) < 0.01f)
        {
            swapPhase();
        }
        
      if (Mathf.Abs((float)(Time.timeSinceLevelLoad - 10f)) < 0.01f)
        {
            swapPhase();
        }*/
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
        director = attackSwapControlPanel.GetComponent<PlayableDirector>();
        director.Play();

        noteholder.GetComponent<BeatScroller>().notePrefab = attackNote;
        player.GetComponent<SpriteRenderer>().sprite = playerFrontSprite;
        //enemy.GetComponent<SpriteRenderer>().sprite = enemyFrontSprite; //we dont have enemy backsprites yet

    }

    public void swaptoDefense()
    {
        director = defenseSwapControlPanel.GetComponent<PlayableDirector>();
        director.Play();

        noteholder.GetComponent<BeatScroller>().notePrefab = defenseNote;
        player.GetComponent<SpriteRenderer>().sprite = playerBackSprite;
        //enemy.GetComponent<SpriteRenderer>().sprite = enemyBackSprite; //we dont have enemy backsprites yet

    }

}
