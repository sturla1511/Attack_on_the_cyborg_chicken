using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// det er 1 gameObjectet med scripte som er kobla til 9 fiender per colone med fiender
public class EnemyDetectorLeft : MonoBehaviour
{
    public UnityEvent die;
    public Transform transform;
    public float numberAlive = 9;

    void Update()
    {
        DetectorVertical();
    }

    public void died() // blir kalt når en av fienden som er koblet til scriptet dør
    {
        numberAlive -= 1;
    }
    void DetectorVertical() // sjeker om alle fiendene på colonen er i live og vilke posisjonen/kordinater colonen har
    {

        if (numberAlive > 0)
        {
            if (transform.position.x < -56)
            {
                die.Invoke(); // kaler Die() i player scriptet som sender spilleren til start menu scenen
            }
        }

    }
    public void Respawn() // reseter scriptet
    {
        numberAlive = 9;
    }
}
