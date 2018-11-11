using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    GameObject player;
    bool isFollowing;
    Vector2 playerPos;
    Vector2 thisPos;
    float visionDist;
    float moveSpeed;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        isFollowing = false;
        visionDist = 5.0f;      //Set visionDist once that's decided on, using 5 temporarily
        moveSpeed = 1.75f;

    }
	
	// Update is called once per frame
	void Update () {
        //Will start following player if player can be seen
        isFollowing = CanSee();
        MoveToPlayer(isFollowing);
		
	}

    public bool CanSee()
    {
        playerPos = player.transform.position;
        thisPos = transform.position;

        //need a value (tbd) to determine if player is close enough to be seen.
        float radius = Mathf.Sqrt(Mathf.Pow(playerPos.x - thisPos.x, 2) + Mathf.Pow(playerPos.y - thisPos.y, 2));
        if(radius <= visionDist) 
        {
            return true;
        }
        return false;
    }

    public void MoveToPlayer(bool isFollowing)
    {
        if(isFollowing)
        {
            transform.Translate((player.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime);
        }
    }
    
}
