using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

/* dete scriptet er for å koble sammen lyd filene med scriptene så andre scripts 
kan si når lydene skal spiles av */
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;  // kobler til scriptet Sound og er for å kune velge lyd
    public static float soundOnOrOff;

    void Awake() 
    {
        foreach (Sound s in sounds) 
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
        
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
    }

    public void SoundOn() // når funksjonen blir kalt av SoundOffOrOn setes lyden til lydclip til det den er sat i unity inspectorn
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }
    public void SoundOff() // når funksjonen blir kalt av SoundOffOrOn seter den all lyd av
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = 0;
            s.source.pitch = s.pitch;
        }
    }


    public void Play(string name) // når funksjonen blir kalt spiles av lyd clipet den blir kalt med
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
