using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/* det scriptet kobler sammen lyd clip med audioManager.

det script gjør også så man kan velge lyd styrken og pitchen til 
forkjelige lydClip i inspectoren til GameObjectet med AudioManager scriptet */

[System.Serializable]
public class Sound 
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}