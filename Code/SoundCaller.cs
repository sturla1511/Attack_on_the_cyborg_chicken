using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundCaller : MonoBehaviour
{
    public UnityEvent checkIfSoundIsOff;
    
    // Start is called before the first frame update
    void Start()
    {
        checkIfSoundIsOff.Invoke();
    }
}
