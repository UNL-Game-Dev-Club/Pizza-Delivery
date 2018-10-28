using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {
    [SerializeField]
    Sprite[] characterSpriteSet;
    int spriteSetLength;
    int spriteIndex;
    SpriteRenderer characterRenderer;

    Sprite[] stillCharacterSpriteSet;

    int startIndex;
    int endIndex;

    string path;

    enum Direction { Forward, Backward, Left, Right };
    Direction playerDirection;

    float deadValue;

    [SerializeField]
    float horizontalAxis;
    [SerializeField]
    float verticalAxis;

    GameplayManager gameplayManager;

    bool isStill;

    float movementDistance;

	// Use this for initialization
	void Start () {
        path = "Sprites/CyberCity/Sprite Sheets";
        LoadYakuza();
        spriteIndex = 0;
        characterRenderer = this.GetComponent<SpriteRenderer>();

        if (characterSpriteSet != null)
            spriteSetLength = characterSpriteSet.Length;

        WalkForward();

        gameplayManager = GameObject.Find("GameplayManager").GetComponent<GameplayManager>();
        deadValue = gameplayManager.DeadValue;
        isStill = true;
        playerDirection = Direction.Forward;
        movementDistance = 2.0f;
	}

    void LoadYakuza()
    {
        characterSpriteSet = Resources.LoadAll<Sprite>(path + "/Yakuza");
        spriteSetLength = characterSpriteSet.Length;
        
        stillCharacterSpriteSet = new Sprite[4];
        stillCharacterSpriteSet[0] = characterSpriteSet[4];
        stillCharacterSpriteSet[1] = characterSpriteSet[1];
        stillCharacterSpriteSet[2] = characterSpriteSet[7];
        stillCharacterSpriteSet[3] = characterSpriteSet[10];
    }
	
	// Update is called once per frame
	void Update () {
        if (!isStill)
        {
            characterRenderer.sprite = characterSpriteSet[spriteIndex++];

            if (spriteIndex == endIndex)
            {
                spriteIndex = startIndex;
            }

            Translate();
        }
        
        verticalAxis = Input.GetAxis("Vertical");
        horizontalAxis = Input.GetAxis("Horizontal");

        if (verticalAxis > deadValue)
        {
            if (playerDirection == Direction.Backward && !isStill)
                return;

            WalkBackward();
        }
        else if (Mathf.Abs(verticalAxis) > deadValue)
        {
            if (playerDirection == Direction.Forward && !isStill)
                return;

            WalkForward();
        }
        else if (horizontalAxis > deadValue)
        {
            Debug.Log("Walking Right");
            if (playerDirection == Direction.Right && !isStill)
                return;

            WalkRight();
        }
        else if (Mathf.Abs(horizontalAxis) > deadValue)
        {
            Debug.Log("Walking Left");
            if (playerDirection == Direction.Left && !isStill)
                return;

            WalkLeft();
        }
        else
        {
            StandStill();
        }
	}

    public void SetSprite(Sprite[] s)
    {
        characterSpriteSet = s;
        spriteSetLength = s.Length;
    }

    public void WalkForward()
    {
        SetAnimationConstraints(3, 6, (int)Direction.Forward);
        isStill = false;
    }

    public void WalkBackward()
    {
        SetAnimationConstraints(0, 3, (int)Direction.Backward);
        isStill = false;
    }

    public void WalkLeft()
    {
        SetAnimationConstraints(6, 9, (int)Direction.Left);
        isStill = false;
    }

    public void WalkRight()
    {
        SetAnimationConstraints(9, 12, (int)Direction.Right);
        isStill = false;
    }

    public void StandStill()
    {
        //SetAnimationConstraints(4, 5, (int)Direction.Forward);
        isStill = true;
        characterRenderer.sprite = stillCharacterSpriteSet[(int)playerDirection];
    }

    public void SetAnimationConstraints(int start, int end, int dir)
    {
        startIndex = start;
        endIndex = end;
        playerDirection = (Direction)dir;
        spriteIndex = start;
    }

    void Translate()
    {
        if (playerDirection == Direction.Backward)
            this.transform.Translate(Vector2.up * movementDistance * Time.deltaTime);
        else if (playerDirection == Direction.Forward)
            this.transform.Translate(Vector2.down * movementDistance * Time.deltaTime);
        else if (playerDirection == Direction.Left)
            this.transform.Translate(Vector2.left * movementDistance * Time.deltaTime);
        else if (playerDirection == Direction.Right)
            this.transform.Translate(Vector2.right * movementDistance * Time.deltaTime);
    }
}
