using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private int KanoTransformations = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchToGame()
    {
        //TODO change scene name once the gameplay loop scene is finalised
        //GetComponentInChildren<AudioSource>().Play();
        SceneManager.LoadScene("Main");
    }

    public void SwitchToCredits()
    {
        //TODO implement credits screen
        //GetComponentInChildren<AudioSource>().Play();
        SceneManager.LoadScene("CreditsScreen");
    }

    public void SwitchToSplash()
    {
        //GetComponentInChildren<AudioSource>().Play();
        SceneManager.LoadScene("SplashScreen");
    }

    public void DULLARD()
    {
        KanoTransformations++;

        if (KanoTransformations == 15)
        {
            KanoTransformations = 0;
            SceneManager.LoadScene("CreditsScreen 1");
        }
    }
}
