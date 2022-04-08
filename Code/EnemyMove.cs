using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator anim;
    static bool DownMoving = true;
    public float startPosition = -81/10;
    public int PlayerScore;

    private Vector2 moveDirection;
    private Vector2 lastMoveDirection;
    public UnityEvent Respawn;

    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate() 
    {
        Move();
    }

    void ProcessInputs() //beveger spileren opp eller ned
    {
        if (DownMoving==true)
        {
            moveDirection = new Vector2(0, -1).normalized;
        }
        else
        {
            moveDirection = new Vector2(0, 1).normalized;
        }

    }
    public void MoveEnemyUp() // blir kalt av EnnemyDetectorUpDown når en fiende er under -65;
    {
        if(DownMoving==true)//flyter alle fiendene et hak til venstere og sier at de skal byne og gå opp
        {
            transform.position = transform.position + new Vector3(-10, 0, 0);
            
            DownMoving = false;
        } 
    }
    public async void MoveEnemyDown() // flyter alle fiendene et hak til venstere og sier at de skal byne og gå opp
    {   
        if(DownMoving==false)
        {
            transform.position = transform.position + new Vector3(-10, 0, 0);
           
            DownMoving = true;
        }  
    }
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    public void AllDead() // blir kalt når det er inngen flere spilere i live og Respawner alle finden og gjør den nye runden lit vanskliger
    {   
        //startPosition -= 10;
        transform.position = new Vector2(startPosition, 0);
        moveSpeed += 1;
        Respawn.Invoke(); //kaler flere scripts for å Respawn dem 
    }
}
