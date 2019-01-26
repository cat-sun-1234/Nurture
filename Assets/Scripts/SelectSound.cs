using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSound : MonoBehaviour
{
    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numberSelectSound = FindObjectsOfType<SelectSound>().Length;

        if (numberSelectSound > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
