using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour {

    // Array to store all characters
    private GameObject[] characters;

    // Array to store all other active objects in the scene
    // --> These are moving objects that are NOT characters (vehicles, timers, etc)
    private GameObject[] activeObjects;

    // Gameplay Variables
    private bool isPaused;

    // Common variables that may be reused across various scripts
    float deadValue;

	// Use this for initialization
	void Start () {
        int numberCharacters = 1; // change this
        characters = new GameObject[numberCharacters];
        // TODO: Initialize all characters in the scene

        int numberActiveObjects = 1; // change this
        activeObjects = new GameObject[numberActiveObjects];
        // TODO: Initialize all active objects in the scene

        // Initialization for gameplay variables
        isPaused = false;

        // Initialization for common variables
        deadValue = 0.5f;
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetAxis("Pause") > deadValue)
        {
            isPaused = !isPaused;
            Pause(isPaused);
        }
	}

    /// <summary>
    /// Pauses all active entities in the current scene
    /// </summary>
    /// <param name="tf"></param>
    private void Pause(bool tf)
    {
        foreach (GameObject currentCharacter in characters)
        {
            // TODO: Develop a script that is a basis for characters (protagonist(s), AI, Enemies, etc)
            currentCharacter.GetComponent<Character>().Pause(tf);
        }

        foreach (GameObject currentCharacter in characters)
        {
            // TODO: Develop a script that is a basis for all active objects in the scene
            currentCharacter.GetComponent<ActiveObject>().Pause(tf);
        }
    }
}
