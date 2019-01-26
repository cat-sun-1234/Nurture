using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
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
        Debug.Log("HMIAIH");
        //TODO change scene name once the gameplay loop scene is finalised
        SceneManager.LoadScene("Main");
    }

    public void SwitchToCredits()
    {
        SceneManager.LoadScene("CreditsScreen");
    }

    public void SwitchToSplash()
    {
        SceneManager.LoadScene("SplashScreen");
    }
}
