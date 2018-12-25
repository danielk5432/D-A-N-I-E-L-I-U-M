using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGUI : MonoBehaviour {

	public int score;


	public Text mText;


	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		mText.text = "Score:" + score;
	}
}
