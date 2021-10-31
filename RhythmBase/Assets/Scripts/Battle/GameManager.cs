using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller theBS;
    public static GameManager instance;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerectNote = 150;
    public int currentScore, currentMultiplier, multiplierTracker;
    public int[] multiplierThresholds;
    public Text scoreText, multiText;
    public float totalNotes, normalHits, goodHits, perfectHits, missedHits;
    public GameObject resultsScreen;
    public Text percentHitText, normalsText, goodsText, perfectsText, missesText, rankText, finalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        // This sets the initial values
        instance = this;
        scoreText.text = "Score: 0";
        currentMultiplier = 1;
        multiplierTracker = 0;
        multiplierThresholds = new int[] {4,12,28};
        totalNotes = FindObjectsOfType<NoteObject>().Length;

    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying){
        //if the game has not started yet
            if(Input.anyKeyDown){
                startPlaying=true;
                theBS.hasStarted = true;

                theMusic.Play();
            }
        } else {
            if (!theMusic.isPlaying && resultsScreen.activeInHierarchy){
                //If the music is not playing and the results screen is not up
                //This does not seem to work so maybe we can do it based on a timer
                resultsScreen.SetActive(true);
                normalsText.text = "" + normalHits;
                goodsText.text = goodHits.ToString();
                // Both of the above accomplish same thing
                perfectsText.text = perfectHits.ToString();
                missesText.text = "" + missedHits;

                float totalHit = normalHits + goodHits + perfectHits;
                float percentHit = (totalHit / totalNotes) * 100f;

                percentHitText.text = percentHit.ToString("F1") + "%";
                //Calculate rank based on percent of hit notes
                string rankVal = "F";
                if(percentHit > 40){
                    rankVal = "D";
                    if(percentHit > 55){
                        rankVal = "C";
                        if (percentHit > 70){
                            rankVal = "B";
                            if(percentHit > 85){
                                rankVal = "A";
                                if (percentHit > 95){
                                    rankVal = "S";
                                }
                            }
                        }
                    }
                }
                rankText.text = rankVal;
                finalScoreText.text = currentScore.ToString();
            }
        }
    }

    public void NoteHit(){
        //What happens when a note is hit
        if(currentMultiplier-1 < multiplierThresholds.Length){
        multiplierTracker++;
        if(multiplierThresholds[currentMultiplier-1] <= multiplierTracker){
            multiplierTracker = 0;
            currentMultiplier++;
        }
        }

        multiText.text = "Multiplier: x" + currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    public void NormalHit(){
        // When you hit a note but poorly
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();
        normalHits++;
    }

    public void GoodHit(){
        // When you hit a note well
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();
        goodHits++;
    }

    public void PerfectHit(){
        // When you hit a note very well
        currentScore += scorePerPerectNote * currentMultiplier;
        NoteHit();
        perfectHits++;
    }

    public void NoteMissed(){
        // When you have a skill issue and need to git gud
        Debug.Log("Missed Note");
        currentMultiplier = 1;
        multiplierTracker = 0;
        multiText.text = "Multiplier: x" + currentMultiplier;
        missedHits++;
    }
}
