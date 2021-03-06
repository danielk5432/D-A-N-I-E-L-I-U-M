﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet: MonoBehaviour
{

	public float Speed;


	private float AngletoMouse;
	// Use this for initialization
	void Start()
	{
		init();
	}

	public void init()
	{
		Player_Move playerposition = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Move>();
		AngletoMouse = playerposition.AngletoMouse;
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		//주요 기능: 자기 자신을 비활성화 한다.
		if (other.transform.gameObject.CompareTag("BulletCollider") || other.transform.gameObject.CompareTag("Enemy"))
		{
			GameObject.Find("Player").GetComponent<Player_Fire>().Bullet_Reload(gameObject);
		}
			//주요 기능 구현 후 아래 문제를 고려해봅시다.
			//다른 총알의 Collider와 충돌한 경우를 판정할 수 있나요?
			//Hint: collision.transform.gameObject.tag를 통해 충돌한 Collider를 Component로 가지고 있는 오브젝트의 Tag를 확인할 수 있다.
	}

	// Update is called once per frame
	void Update()
	{
		//Time_Limit();
		transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime * Mathf.Sin(Mathf.Deg2Rad * AngletoMouse), transform.position.y + Speed * Time.deltaTime * Mathf.Cos(Mathf.Deg2Rad * AngletoMouse) * (-1));
		//transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime * Mathf.Sin(Mathf.Deg2Rad * AngletoMouse), transform.position.y + Speed * Time.deltaTime * Mathf.Cos(Mathf.Deg2Rad * AngletoMouse) * (-1));
	}
	/*
	public void Time_Limit()
	{
		if (Time.deltaTime - Summon_Time >= 3)
		{
			GameObject.FindGameObjectWithTag("Bullet");
		}
	}*/

	//Vector2(Mathf.Sin(Mathf.Deg2Rad * AngletoMouse) * (-1), Mathf.Cos(Mathf.Deg2Rad * AngletoMouse))

}
