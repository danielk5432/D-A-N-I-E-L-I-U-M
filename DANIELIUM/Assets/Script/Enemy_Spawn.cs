using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour {
	Enemy1Pool Enemy1;
	// Use this for initialization
	void Start () {
		Enemy1 = GameObject.FindGameObjectWithTag("Pool").GetComponent<Enemy1Pool>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Enemy1Spawn()
	{
		GameObject proj = Enemy1.Pooled_Enemy1.Dequeue();
		proj.SetActive(true);
		proj.transform.position = transform.position;
	}
}
