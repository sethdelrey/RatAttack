using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameObject[] pauseObjects;
    GameObject[] finishObjects;
    [SerializeField]
    Sprite checkedSprite;
    [SerializeField]
    Sprite uncheckedSprite;
    public static bool isHardDiff;
    Rat ratController;
    public AudioClip buttonSound;
    public AudioSource audioSource;
    public AudioClip mainMenuMusic;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        finishObjects = GameObject.FindGameObjectsWithTag("ShowOnFinish");
        
        hidePaused();
        hideFinished();

        if (Application.loadedLevelName == "MainScene")
        {
            ratController = GameObject.FindGameObjectWithTag("Player").GetComponent<Rat>();
        }

        if (Application.loadedLevelName == "MainMenu")
        {
            audioSource.Play();
        }

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1 && ratController.alive == true)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0 && ratController.alive == true)
            {
                Time.timeScale = 1;
                hidePaused();
            }
        }

        if (Time.timeScale == 0 && ratController.alive == false)
        {
            showFinished();
        }

    }

    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonSound);
        
    }

    IEnumerator WaitForPlayButtonSound()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSecondsRealtime(buttonSound.length - .3f);
        LoadLevel("MainScene");

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    public void SelectHardMode()
    {   
        if (isHardDiff)
        {
            GameObject.FindGameObjectWithTag("CheckBox").GetComponent<Image>().sprite = uncheckedSprite;
            isHardDiff = false;
        }
        else
        {
            GameObject.FindGameObjectWithTag("CheckBox").GetComponent<Image>().sprite = checkedSprite;
            isHardDiff = true;
        }
        
    }

    public void PlayButtonOnClick()
    {
        PlayButtonSound();
        StartCoroutine(WaitForPlayButtonSound());
    }

    public void RestartButtonOnClick()
    {
        PlayButtonSound();
        StartCoroutine(WaitForRestartButtonSound());
    }

    IEnumerator WaitForRestartButtonSound()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSecondsRealtime(buttonSound.length - .3f);
        Reload();

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    public void MainMenuButtonOnClick()
    {
        PlayButtonSound();
        StartCoroutine(WaitForMainMenuButtonSound());
    }

    IEnumerator WaitForMainMenuButtonSound()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSecondsRealtime(buttonSound.length - .3f);
        LoadLevel("MainMenu");

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    //Reloads the Level
    public void Reload()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene());
        Application.LoadLevel(Application.loadedLevel);
    }

    //controls the pausing of the scene
    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    // shows objects with ShowOnEnd tag
    public void showFinished()
    {
        foreach (GameObject g in finishObjects)
        {
            g.SetActive(true);
        }
    }

    // hides objects with ShowOnEnd tag
    public void hideFinished()
    {
        foreach (GameObject g in finishObjects)
        {
            g.SetActive(false);
        }
    }

    //loads inputted level
    public void LoadLevel(string level)
    {
        //SceneManager.LoadScene(level);
        Application.LoadLevel(level);
    }
}
