using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class destroyBullet : MonoBehaviour
{
    public UnityEvent Score;
    

    public void BulletDestroy ()
    {
        Score.Invoke();
    }

    

}
