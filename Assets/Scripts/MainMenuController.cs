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
        KanoTransformations = 0;
    }
    #region Scene Data
    string PPN;
    int PPV;
    public void SetPlayerPrefName(string _N)
    {
        PPN = _N;
    }
    public void SetPlayerPrefValue(int _V)
    {
        PPV = _V;
    }
    public void SetPlayerPref()
    {
        PlayerPrefs.SetInt(PPN, PPV);
        Debug.Log(PPN + ": " + PPV);
    }
    #endregion
    public void ActivateObject(GameObject _G)
    {
        _G.SetActive(true);
    }
    public void DeactivateObject(GameObject _G)
    {
        _G.SetActive(false);
    }

    public void GoToSelection()
    {
        SceneManager.LoadScene("SelectionScene");
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
