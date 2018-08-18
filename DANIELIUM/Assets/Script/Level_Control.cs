using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Control : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Test_Level();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Level_1()
	{

	}

	void Test_Level()
	{
		GameObject.Find("Enemy Spawn1").GetComponent<Enemy_Spawn>().Enemy1Spawn();
	}

}
