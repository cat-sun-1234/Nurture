using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController:MonoBehaviour
{
    AudioSource aPlayer;
    private void Awake()
    {
        aPlayer = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip _Sound)
    {
        Debug.Log("Playing: " + _Sound.name);
        if (aPlayer.clip != _Sound)
        {
            aPlayer.clip = _Sound;
        }
        aPlayer.Play();
    }
}
