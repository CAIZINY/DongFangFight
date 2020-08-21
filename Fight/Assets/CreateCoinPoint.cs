using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCoinPoint : MonoBehaviour
{
    public GameObject coinObject;

    public float timer;
    public float createPeriod;

    void FixedUpdate()
    {
        timer = timer + Time.deltaTime;
        if (timer >= createPeriod)
        {
            timer = 0f;
            Instantiate<GameObject>(coinObject);
        }
    }
}
