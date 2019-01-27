using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
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
        if (soundPlayer.clip != _Sound)
        {
            soundPlayer.clip = _Sound;
        }
        if (!soundPlayer.isPlaying)
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
        Debug.Log("Playing: " + _Track.name);
        musicPlayer.Play();
    }
    public void PlayBackgroundTrack()
    {
        Debug.Log("Playing: " + musicPlayer.clip.name);
        musicPlayer.Play();
    }
}
