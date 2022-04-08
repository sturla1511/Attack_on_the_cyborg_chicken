using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SoundOfforOn : MonoBehaviour
{
    public static bool Switch = true;
    public UnityEvent SoundOn;
    public UnityEvent SoundOff;
    public Animator anim;

    public void SoundSwitch() //skrur lyd av eller på av hengi av om den er på eller av
    {
        if(Switch == true)
        {
            Switch = false;
        }
        else if(Switch == false)
        {
            Switch = true;
        }
        anim.SetBool("OffOrOn",  Switch);
    }

    public void SoundCheck() //sjeker om lyden skal være av eller på og sier fra til audioManger scriptet
    {
        if(Switch == true)
        {
            SoundOn.Invoke();
        }
        if(Switch == false)
        {
            SoundOff.Invoke();
        }
    }
}
