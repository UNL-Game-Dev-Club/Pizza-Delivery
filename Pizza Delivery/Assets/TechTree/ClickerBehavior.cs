using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerBehavior : MonoBehaviour {

    TechTree techTree;
    Text clickerText;

	// Use this for initialization
	void Start () {
        techTree = new TechTree();
        clickerText = GameObject.Find("ClickerText").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
            techTree.WingPoints++;

        clickerText.text = "" + techTree.WingPoints;
	}
}
