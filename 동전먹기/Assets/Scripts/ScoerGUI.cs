using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoerGUI : MonoBehaviour {
    private Text mText;

	// Use this for initialization
	void Start () {
        mText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        int score = Score.instance.score;
        string scoreAddZero = score.ToString("000");
        mText.text = "Score:" + scoreAddZero;
	}
}
