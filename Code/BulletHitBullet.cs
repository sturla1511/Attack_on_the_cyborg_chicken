using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitBullet : MonoBehaviour
{
    public bool bulletHitBullet;
    // Update is called once per frame
    void Update()
    {
        if(bulletHitBullet==true){
            Destroy(gameObject);
        }
        
    }
}
