using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject blulletPrefab;
    public bool ShootDelay = false;
    public bool ShieldDelay = false;
    public Animator animPlayerArm;
    public bool moveArm;
    public bool shieldArm;

    // Update is called once per frame
    void Update() //sjeker om space eller c blir tryket
    {
        animPlayerArm.SetBool("moveArm",  moveArm);
        animPlayerArm.SetBool("shieldArm",  shieldArm);
        
        if(Input.GetButtonDown("Jump") && ShootDelay == false)
        {
            Shoot();
        }

        if(Input.GetButtonDown("C") &&  ShieldDelay == false)
        {
            FindObjectOfType<AudioManager>().Play("vomm");
            Shield();
        }
    }
    
    public void Shoot () // skyte animatjonen til armen blir spilt av og et skud (bullet) blir Instantiata
    {   moveArm = true;
        animPlayerArm.SetBool("moveArm",  moveArm);
        moveArm = false;
        Instantiate(blulletPrefab, firePoint.position,  firePoint.rotation);
    }

    public void Shield() // sjhol animatjonen til armen blir spilt av. under animasjonen til sjhole blir en hitbox aktiv og deaktivert
    {
        shieldArm = true;
        animPlayerArm.SetBool("shieldArm",  shieldArm);
        shieldArm = false;
    }
}
