using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void ActivateMenu(GameObject _Menu)
    {
        _Menu.SetActive(true);
    }
    public void DeactivateMenu(GameObject _Menu)
    {
        _Menu.SetActive(false);
    }

    public void SwitchToGame()
    {
        //TODO change scene name once the gameplay loop scene is finalised
        SceneManager.LoadScene("DayNightCycleTesting");
    }

    public void SwitchToCredits()
    {
        //TODO implement credits screen
    }

    public void SwitchToSplash()
    {
        SceneManager.LoadScene("SplashScreen");
    }
}
