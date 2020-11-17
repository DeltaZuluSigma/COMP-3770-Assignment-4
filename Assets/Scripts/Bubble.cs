using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private float timer;
    public bool isPopped;
    public bool isMissed;
    private Ray ray;

    void Awake()
    {
        timer = 10.0f;
    }

    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        missedCheck();
    }

    void OnMouseDown()
    {
        isPopped = true;
    }

    public void missedCheck()
    {
        if (timer <= 0)
        {
            isMissed = true;
            timer = 10.0f;
        }
        else isMissed = false;
    }
}

