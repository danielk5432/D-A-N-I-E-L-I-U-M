using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthGUI : MonoBehaviour {
	private Text mText;


	public int Health = 3;

	// Use this for initialization
	void Start()
	{
		mText = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update()
	{
		string SHealth;
		switch (Health)
		{
			case 3:
				SHealth = "OOO";
				break;
			case 2:
				SHealth = "XOO";
				break;
			case 1:
				SHealth = "XXO";
				break;
			default:
				SHealth = "XXX";
				break;
		}
		mText.text = "Health:" + SHealth;
	}

	public void HReset()
	{
		Health = 3;
	}

	public void HDamage()
	{
		Health--;
	}

}
