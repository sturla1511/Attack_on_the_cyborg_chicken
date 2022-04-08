using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NumberAlive : MonoBehaviour
{
    public float numberAlive = 45;
    public UnityEvent AllDead;

    // Start is called before the first frame update
    void Start()
    {
        numberAlive = 45;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OneDied() {
        numberAlive -= 1;
        if (numberAlive <= 0)
        {
            AllDead.Invoke();
        }
    }
    public void Respawn()
    {
        numberAlive = 45;
    }
}
