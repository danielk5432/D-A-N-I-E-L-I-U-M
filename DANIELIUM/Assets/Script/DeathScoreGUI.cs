using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScoreGUI : MonoBehaviour {

	public int score;
	Player_Move Score;

	public Text mText;

	// Use this for initialization
	void Start () {
		Score = GameObject.Find("Player").GetComponent<Player_Move>();
		score = Score.score;
	}
	
	// Update is called once per frame
	void Update () {
		mText.text = "Your score is " + Score.score;
	}
}
