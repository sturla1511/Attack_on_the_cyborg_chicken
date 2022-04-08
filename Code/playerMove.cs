using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator animPlayer;
    public float moveY;

    private Vector2 moveDirection;
    private Vector2 lastMoveDirection;

    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
    }
    void ProcessInputs()
    {
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(0, moveY).normalized;
        animPlayer.SetFloat("moveDirectionY",  moveDirection.y);
    } 
    void Move()
    {
        rb.velocity = new Vector2(0, moveDirection.y * moveSpeed);
    }
}


