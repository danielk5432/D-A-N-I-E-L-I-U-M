using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour {
	Enemy_Pool Enemy1;
	// Use this for initialization
	void Start () {
		Enemy1 = GameObject.Find("Level Control").GetComponent<Enemy_Pool>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Enemy1Spawn()
	{
		GameObject proj = Enemy1.Pooled_Enemy1.Dequeue();
		proj.SetActive(true);
		proj.transform.position = transform.position;
		proj.GetComponent<Enemy1>().Init();
	}
}
