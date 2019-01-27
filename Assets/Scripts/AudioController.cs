using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController:MonoBehaviour
{
    AudioSource soundPlayer;
    AudioSource musicPlayer;
    private void Awake()
    {
        soundPlayer = gameObject.AddComponent<AudioSource>();
        musicPlayer = gameObject.AddComponent<AudioSource>();
        musicPlayer.playOnAwake = true;
        musicPlayer.loop = true;
    }
    public void PlaySoundEffect(AudioClip _Sound)
    {
        Debug.Log("Playing: " + _Sound.name);
        if (soundPlayer.clip != _Sound)
        {
            soundPlayer.clip = _Sound;
        }
        if(!soundPlayer.isPlaying)
        {
            soundPlayer.Play();
        }
    }
    public void ChangeBackgroundTrack(AudioClip _Track)
    {
        if (musicPlayer.clip != _Track)
        {
            musicPlayer.clip = _Track;
        }
    }
}
