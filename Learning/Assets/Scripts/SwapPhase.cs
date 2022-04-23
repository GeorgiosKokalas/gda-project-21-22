using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class SwapPhase : MonoBehaviour
{

    public GameObject noteholder;
    public GameObject bandit;
    public GameObject attackNote;
    public GameObject defenseNote;
    
    public TimelineAsset bouncyDef;
    public TimelineAsset bouncyAtk;
    private bool defensePhase;

    // Start is called before the first frame update
    void Start()
    {
        defensePhase = true;
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

    public void changeBounce()
    {
        if (defensePhase)
        {
            bandit.GetComponent<PlayableDirector>().playableAsset = bouncyAtk;
            bandit.GetComponent<PlayableDirector>().Play();
            defensePhase = false;
        }
        else
        {
            bandit.GetComponent<PlayableDirector>().playableAsset = bouncyDef;
            bandit.GetComponent<PlayableDirector>().Play();
            defensePhase = true;
        }
    }

    public void swapPhase()
    {
        if (defensePhase)
        {
            noteholder.GetComponent<BeatScroller>().notePrefab = attackNote;
            changeBounce();
        }
        else
        {
            noteholder.GetComponent<BeatScroller>().notePrefab = defenseNote;
            changeBounce();
        }

    }

    /*public void swaptoAttack()
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

    }*/

}
