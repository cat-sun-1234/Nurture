using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController:MonoBehaviour

{
    public static AudioController reference = null;  

    AudioSource soundPlayer;
    AudioSource musicPlayer;
    Component[] music;

    AudioSource[] musicSources;

    private void Awake()
    {
        reference = this;

        soundPlayer = gameObject.AddComponent<AudioSource>();
        musicPlayer = gameObject.AddComponent<AudioSource>();
        music = gameObject.GetComponents(typeof(AudioSource));

        musicSources = new AudioSource[music.Length];
        for (int i = 0; i < music.Length; i++){
            musicSources[i] = (AudioSource)music[i];
        }
        print(musicSources[1]);

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
    public void ChangeTrack(int trackNum)
    {
        print("here: " + trackNum);
        switch (trackNum)
        {
            case 0:
                musicSources[0].Play();
                musicSources[1].Stop();
                musicSources[2].Stop();
                musicSources[3].Stop();
                musicSources[4].Stop();
                break;
            case 1:
                musicSources[1].Play();
                musicSources[0].Stop();
                musicSources[2].Stop();
                musicSources[3].Stop();
                musicSources[4].Stop();
                break;
            case 2:
                musicSources[2].Play();
                musicSources[1].Stop();
                musicSources[0].Stop();
                musicSources[3].Stop();
                musicSources[4].Stop();
                break;
            case 3:
                musicSources[3].Play();
                musicSources[1].Stop();
                musicSources[2].Stop();
                musicSources[0].Stop();
                musicSources[4].Stop();
                break;
            case 4:
                musicSources[4].Play();
                musicSources[1].Stop();
                musicSources[2].Stop();
                musicSources[3].Stop();
                musicSources[0].Stop();
                break;
        }
    }
}
