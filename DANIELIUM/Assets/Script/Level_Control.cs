using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Control : MonoBehaviour {


	public bool Alive = false;
	public int[] ECount = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
	private int sum = 0;

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
		if (!Alive)
			SceneManager.LoadScene("DeadScene");

		sum = ECount[0] + ECount[1] + ECount[2];
	}

	IEnumerator Test_Level()
	{
		Spawn1.Enemy1Spawn();
		Spawn3.Enemy1Spawn();
		Spawn7.Enemy1Spawn();

		yield return new WaitForSeconds(10);
		while (ECount[0] > 1) yield return 0;


		Spawn2.Enemy1Spawn();
		Spawn4.Enemy1Spawn();
		Spawn6.Enemy1Spawn();
		Spawn8.Enemy1Spawn();

		while (ECount[0] > 3) yield return 0;

		Spawn1.Enemy1Spawn();
		Spawn2.Enemy1Spawn();
		Spawn4.Enemy1Spawn();
		Spawn6.Enemy1Spawn();
		Spawn7.Enemy1Spawn();
		Spawn8.Enemy1Spawn();

		yield return new WaitForSeconds(10);
		while (ECount[0] > 4) yield return 0;

		Spawn1.Enemy1Spawn();
		Spawn2.Enemy1Spawn();
		Spawn4.Enemy1Spawn();
		Spawn5.Enemy1Spawn();
		Spawn6.Enemy1Spawn();
		Spawn7.Enemy1Spawn();
		Spawn8.Enemy1Spawn();

		while (ECount[0] > 4) yield return 0;

		Spawn1.Enemy2Spawn();
		Spawn5.Enemy2Spawn();

		while (ECount[1] > 0) yield return 0;

		Spawn1.Enemy1Spawn();
		Spawn5.Enemy1Spawn();
		Spawn3.Enemy2Spawn();
		Spawn7.Enemy2Spawn();

		yield return new WaitForSeconds(10);
		while (ECount[1] > 0) yield return 0;

		Spawn2.Enemy2Spawn();
		Spawn3.Enemy2Spawn();
		Spawn4.Enemy2Spawn();
		Spawn6.Enemy2Spawn();
		Spawn7.Enemy2Spawn();
		Spawn8.Enemy2Spawn();

		yield return new WaitForSeconds(15);
		while (sum > 1) yield return 0;

		Spawn1.Enemy1Spawn();
		Spawn2.Enemy2Spawn();
		Spawn3.Enemy1Spawn();
		Spawn4.Enemy2Spawn();
		Spawn5.Enemy1Spawn();
		Spawn6.Enemy2Spawn();
		Spawn7.Enemy1Spawn();
		Spawn8.Enemy2Spawn();

		yield return new WaitForSeconds(15);
		while (sum > 3) yield return 0;

		Spawn3.Enemy3Spawn();

		while (ECount[2] > 0) yield return 0;

		Spawn1.Enemy3Spawn();
		Spawn5.Enemy3Spawn();

		while (ECount[2] > 0) yield return 0;

		Spawn2.Enemy1Spawn();
		Spawn3.Enemy2Spawn();
		Spawn5.Enemy3Spawn();
		Spawn7.Enemy1Spawn();
		Spawn8.Enemy2Spawn();

		while (sum > 4) yield return 0;

		while (true)
		{
			Spawn2.Enemy1Spawn();
			Spawn3.Enemy2Spawn();
			Spawn5.Enemy3Spawn();
			Spawn7.Enemy1Spawn();
			Spawn8.Enemy2Spawn();

			while (sum > 5) yield return 0;
		}


	}
}
