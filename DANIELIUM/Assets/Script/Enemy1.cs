using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(Fire());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Fire()
	{
		//총알 발사 스크립트 작성

		yield return new WaitForSeconds(3);
		/*if(비활성화)
		  {return;}*/
	}

	/*
	function Fade()
	{
		for (var f = 1.0; f >= 0; f -= 0.1)
		{
			var c = renderer.material.color;
			c.a = f;
			renderer.material.color = c;
			yield WaitForSeconds(0.1);
	}
	*/
}
