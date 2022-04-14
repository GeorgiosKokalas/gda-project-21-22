using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //------VARIABLES-----------------------------
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject audioPlayer;


    //------BUILT-IN FUNCTIONS-----------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                StartCoroutine(Resume());
            }
            else
            {
                Pause();
            }
        }
    }

//------CUSTOM-MADE FUNCTIONS----------------------
    IEnumerator Resume()
    {
        pauseMenuUI.SetActive(false);
        int seconds = 5;
        while (seconds > 0){
            Debug.Log(seconds+" seconds left.");
            yield return new WaitForSecondsRealtime(1f);
            seconds--;
        }
        Time.timeScale = 1f; 
        GameIsPaused = false;
        audioPlayer.GetComponent<AudioSource>().Play();
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        audioPlayer.GetComponent<AudioSource>().Pause();
    }
}
