using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    private bool isPaused;

	// Use this for initialization
	void Start ()
    {
        isPaused = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Pause(bool tf)
    {
        isPaused = tf;
    }
}
