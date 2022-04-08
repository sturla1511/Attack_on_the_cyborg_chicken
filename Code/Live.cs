using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Live : MonoBehaviour
{
    public float hit;
    public bool hitAnim;
    public Animator anim;
    public void PlayerHit() // blir kalt når spiler blir tefet og et hjerte blir ødelakt
    {
        hit=hit-1;
        if(hit<=0)
        {
            hitAnim=true;
            anim.SetBool("hit",  hitAnim);
        }
    }
}
