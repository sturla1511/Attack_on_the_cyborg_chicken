using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public int health = 10;
    public int enemyPointsValue;
    public Animator anim;
    public float AnimOffset;
    public bool die;
    public Transform transform;
    public GameObject deathEffect;
    public UnityEvent died;
    public UnityEvent Detector;
    public UnityEvent addToScore;
    public TextWriter TextWriter;

    void Awake()
    {
        AnimOffset = Random.Range(0,  7);
    }
    
    void Update()
    {
        Animate();
        if (transform.position.x > 70)
        {
            Die();
        }
    }

    public void TakeDamage (int damage) //blir kalt av Bullet når Bullet trfer en fiende
    {
        health -= damage;
        TextWriter.addPoints = enemyPointsValue;
        addToScore.Invoke(); //kaler addToScore funksjonen i TextWriter
        if (health <= 0)
        {
            Die(); 
            died.Invoke(); 
        }

    }

    void Die()
    {
        FindObjectOfType<AudioManager>().Play("aHh");
        
        die = true; 

        Detector.Invoke(); // kaler funksjonen died() i både EnemyDetectorLeft og EnemyDetectorUpDown

    }

    public void Respawn()// blir kalt av EnemyMove scriptet når alle enemys er døde
    {
        die = false;
    }

    void Animate() 
    {
        anim.SetBool("die",  die);
        anim.SetFloat("Offset", AnimOffset/10);
    }

}
