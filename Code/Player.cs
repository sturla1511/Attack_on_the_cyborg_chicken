using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    public int health = 50;

    public UnityEvent Hit;
    public UnityEvent setScore;
    public Animator AnimPlayer;
    public Animator animArm;
    public bool die = false;


    public void TakeDamage (int damage) //det inni her skjer ver gang spileren blir trefet
    {
        
        health -= damage;

        Hit.Invoke(); //Hit.Invoke() sier til skriptet Live at spileren har blit skadet

        FindObjectOfType<AudioManager>().Play("bowowh");

        if (health <= 0)
        {
            Die();
        }

    }

    public void Die () // blir kalt av TakeDamage(); når spileren ikke lenger har noe live
    {
        if (die == false) // så det inni if-en ikke jetar seg i tilfel Die blir kalt to ganger på rad.
        {
            FindObjectOfType<AudioManager>().Play("AkHAkH");
            setScore.Invoke(); // kaller funksjonen setScore() i TextWriter scriptet
        }
        
        die = true;
        AnimPlayer.SetBool("Die", die);
        animArm.SetBool("Die", die);

        LoadNextLevel();
    }

    public Animator transition;
    public float transitionTime;

    public void LoadNextLevel()//sender spilleren til start menyen
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }
    
    IEnumerator LoadLevel(int LevelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex);

    }

}
