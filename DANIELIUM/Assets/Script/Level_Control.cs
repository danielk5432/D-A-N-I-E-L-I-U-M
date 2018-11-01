using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Control : MonoBehaviour {


	public bool Alive = false;


	Enemy_Spawn Spawn1;
	Enemy_Spawn Spawn2;
	Enemy_Spawn Spawn3;
	Enemy_Spawn Spawn4;
	Enemy_Spawn Spawn5;
	Enemy_Spawn Spawn6;
	Enemy_Spawn Spawn7;
	Enemy_Spawn Spawn8;


	// Use this for initialization
	void Start () {
		Spawn1 = GameObject.Find("Enemy Spawn1").GetComponent<Enemy_Spawn>();
		Spawn2 = GameObject.Find("Enemy Spawn2").GetComponent<Enemy_Spawn>();
		Spawn3 = GameObject.Find("Enemy Spawn3").GetComponent<Enemy_Spawn>();
		Spawn4 = GameObject.Find("Enemy Spawn4").GetComponent<Enemy_Spawn>();
		Spawn5 = GameObject.Find("Enemy Spawn5").GetComponent<Enemy_Spawn>();
		Spawn6 = GameObject.Find("Enemy Spawn6").GetComponent<Enemy_Spawn>();
		Spawn7 = GameObject.Find("Enemy Spawn7").GetComponent<Enemy_Spawn>();
		Spawn8 = GameObject.Find("Enemy Spawn8").GetComponent<Enemy_Spawn>();
		StartCoroutine(Test_Level());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Level_1()
	{

	}

	IEnumerator Test_Level()
	{
		Spawn1.Enemy1Spawn();
		Spawn2.Enemy1Spawn();
		Spawn3.Enemy1Spawn();
		Spawn4.Enemy1Spawn();
		Spawn5.Enemy1Spawn();
		Spawn6.Enemy1Spawn();
		Spawn7.Enemy1Spawn();
		Spawn8.Enemy1Spawn();
		yield return new WaitForSeconds(3);
	}
}
