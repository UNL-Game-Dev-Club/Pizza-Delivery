using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour {

    // Array to store all characters in the scene
    private GameObject[] characters; // Maybe use ArrayList instead??????????
    private int numberCharacters;

    // Array to store all other active objects in the scene
    // --> These are moving objects that are NOT characters (vehicles, timers, etc)
    private GameObject[] activeObjects;
    private int numberActiveObjects;

    // Array to store all other inactive but interactable objects
    private GameObject[] interactableObjects;
    private int numberInteractableObjects;

    // Gameplay Variables
    private bool isPaused;
    LevelTimerBehavior levelTimer;

    // Common variables that may be reused across various scripts
    float deadValue;

	// Use this for initialization
	void Start () {
        numberCharacters = 1; // change this -- Possibly find a way to do this dynamically (tags???)
        characters = new GameObject[numberCharacters];
        // TODO: Initialize all characters in the scene

        numberActiveObjects = 1;
        activeObjects = new GameObject[numberActiveObjects];
        // TODO: Initialize all active objects in the scene

        numberInteractableObjects = 1;
        interactableObjects = new GameObject[numberInteractableObjects];
        // TODO: Initialize all interactable objects in the scene

        // Initialization for gameplay variables
        isPaused = false;
        levelTimer = GameObject.Find("LevelTimer").GetComponent<LevelTimerBehavior>();

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

        foreach (GameObject currentActiveObject in activeObjects)
        {
            // TODO: Develop a script that is a basis for all active objects in the scene
            currentActiveObject.GetComponent<ActiveObject>().Pause(tf);
        }

        foreach (GameObject currentInteractableObject in interactableObjects)
        {
            // TODO: Develop a script that is a basis for all active objects in the scene
            currentInteractableObject.GetComponent<InteractableObject>().Pause(tf);
        }
    }

    /// <summary>
    /// Dead value used for determining valid input values
    /// </summary>
    public float DeadValue
    {
        // JUST the getter
        get
        {
            return deadValue;
        }
    }
}
