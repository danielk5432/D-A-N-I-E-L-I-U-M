using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour {


	Enemy_Pool Enemy;
	Level_Control Count;
	
	// Use this for initialization
	void Start () {
		Enemy = GameObject.Find("Level Control").GetComponent<Enemy_Pool>();
		Count = GameObject.Find("Level Control").GetComponent<Level_Control>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Enemy1Spawn()
	{
		GameObject proj = Enemy.Pooled_Enemy1.Dequeue();
		proj.SetActive(true);
		proj.transform.position = transform.position;
		proj.GetComponent<Enemy1>().Init();
		Count.ECount[0]++;
	}
	public void Enemy2Spawn()
	{
		GameObject proj = Enemy.Pooled_Enemy2.Dequeue();
		proj.SetActive(true);
		proj.transform.position = transform.position;
		proj.GetComponent<Enemy2>().Init();
		Count.ECount[1]++;
	}
	public void Enemy3Spawn()
	{
		GameObject proj = Enemy.Pooled_Enemy3.Dequeue();
		proj.SetActive(true);
		proj.transform.position = transform.position;
		proj.GetComponent<Enemy3>().Init();
		Count.ECount[2]++;
	}
}
