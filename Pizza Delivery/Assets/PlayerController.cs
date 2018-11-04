using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    bool isStill;

    float deadValue;

    [SerializeField]
    float horizontalAxis;
    [SerializeField]
    float verticalAxis;

    GameplayManager gameplayManager;

    float movementDistance;
    Animator anm;
    
    string path;

    // Use this for initialization
    void Start () {
        gameplayManager = GameObject.Find("GameplayManager").GetComponent<GameplayManager>();
        anm = GetComponent<Animator>();
        deadValue = gameplayManager.DeadValue;
        movementDistance = 2.0f;
        isStill = true;
    }
	
	// Update is called once per frame
	void Update () {
        
        Translate();
        verticalAxis = Input.GetAxisRaw("Vertical");
        horizontalAxis = Input.GetAxisRaw("Horizontal");

    }

    void Translate()
    {
        //movementDistance will be scaled down by a factor of sqrt(2) when moving diagonally to keep speed constant regardless of movement direction.

        if ((verticalAxis > deadValue) && horizontalAxis > deadValue)
        {
            //Translate UpRight
            this.transform.Translate((Vector2.up + Vector2.right) * (movementDistance / Mathf.Sqrt(2)) * Time.deltaTime);
            anm.Play("PizzaGuyWalkUp");

        }
        else if ((verticalAxis > deadValue) && (Mathf.Abs(horizontalAxis) > deadValue))
        {
            //Translate UpLeft
            this.transform.Translate((Vector2.up + Vector2.left) * (movementDistance / Mathf.Sqrt(2)) * Time.deltaTime);
            anm.Play("PizzaGuyWalkUp");
        }
        else if ((Mathf.Abs(verticalAxis) > deadValue) && horizontalAxis > deadValue )
        {
            //Translate DownRight
            this.transform.Translate((Vector2.down + Vector2.right) * (movementDistance / Mathf.Sqrt(2)) * Time.deltaTime);
            anm.Play("PizzaGuyWalkDown");

        }
        else if ((Mathf.Abs(verticalAxis) > deadValue ) && (Mathf.Abs(horizontalAxis) > deadValue))
        {
            //Translate DownLeft
            this.transform.Translate((Vector2.down + Vector2.left) * (movementDistance / Mathf.Sqrt(2)) * Time.deltaTime);
            anm.Play("PizzaGuyWalkDown");


        }
        else if (verticalAxis > deadValue)
        {
            //Translate Up
            this.transform.Translate(Vector2.up * movementDistance * Time.deltaTime);
            anm.Play("PizzaGuyWalkUp");
        }
        else if (Mathf.Abs(verticalAxis) > deadValue)
        {
            //Translate Down
            this.transform.Translate(Vector2.down * movementDistance * Time.deltaTime);
            anm.Play("PizzaGuyWalkDown");

        }
        else if (horizontalAxis > deadValue)
        {
            //Translate Right
            this.transform.Translate(Vector2.right * movementDistance * Time.deltaTime);
            anm.Play("PizzaGuyWalkRight");

        }
        else if (Mathf.Abs(horizontalAxis) > deadValue)
        {
            //Translate Left
            this.transform.Translate(Vector2.left * movementDistance * Time.deltaTime);
            anm.Play("PizzaGuyWalkLeft");

        }
        else
        {
            isStill = true;
            anm.Play("PizzaGuyWalkDown");
        }
    }
}
