using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void SwitchToGame()
    {
        //TODO change scene name once the gameplay loop scene is finalised
        SceneManager.LoadScene("DayNightCycleTesting");
    }

    public void SwitchToCredits()
    {
        //TODO implement credits screen
        SceneManager.LoadScene("CreditsScreen");
    }

    public void SwitchToSplash()
    {
        SceneManager.LoadScene("SplashScreen");
    }
}
