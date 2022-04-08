using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// det er 1 gameObjectet med scripte som er kobla til 5 fiender per rad med fiender
public class EnemyDetectorUpDown : MonoBehaviour
{
    public UnityEvent MoveEnemyDown;
    public UnityEvent MoveEnemyUp;
    public Transform transform;
    public float numberAlive = 5;

    void Update()
    {
        Detector();
    }

    public void died() // blir kalt når en av fienden som er koblet til scriptet dør
    {
        numberAlive -= 1;
    }
    void Detector() // sjeker om alle fiendene på raden er i live og vilke posisjonen/kordinater raden har
    {

        if (numberAlive >= 1)
        {
            if (transform.position.y > 60)
            {
                MoveEnemyDown.Invoke(); // kaler MoveEnemyDown i EnemyMove Scripte
            }

            if (transform.position.y < -65)
            {
                MoveEnemyUp.Invoke(); // kaler MoveEnemyUp i EnemyMove Scripte
            }
        }

    }
    public void Respawn() // reseter scriptet
    {
        numberAlive = 5;
    }

}
