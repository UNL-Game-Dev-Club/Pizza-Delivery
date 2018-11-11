using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimerBehavior : MonoBehaviour {

    float time;
    bool isRunning;

	// Use this for initialization
	void Start () {
        time = 5.0f; // Change this value -- Just an initial dummy value
	}
	
	// Update is called once per frame
	void Update () {
		if (isRunning)
        {
            if ((time -= Time.deltaTime) > 0)
            {
                // Update GUI?
            }
            else
            {
                time = 0;
                isRunning = false;
            }
        }
	}

    /// <summary>
    /// Sets the level timer duration to the given time
    /// </summary>
    /// <param name="t"></param>
    private void SetTimer(float t)
    {
        if (!isRunning)
        {
            time = t;
        }
        else
        {
            // Cannot interfere with an active timer
        }
    }

    /// <summary>
    /// Sets a flag to start the level timer
    /// </summary>
    private void StartTimer()
    {
        isRunning = true;
    }

    /// <summary>
    /// Sets the level timer to the given time and starts it
    /// </summary>
    /// <param name="t">Duration for the timer to run</param>
    public void SetTimerAndStart(float t)
    {
        SetTimer(t);
        StartTimer();
    }

    public void PauseTimer()
    {
        isRunning = false;
    }
}
