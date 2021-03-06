﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour {

	public float speed;
	public float AngletoMouse;
	public int score;

	Level_Control level;
	Vector2 movement;
	Vector3 Mouse_Position;
	ScoreGUI Score;

	private Rigidbody2D rb2d;


	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(transform.gameObject);
		rb2d = GetComponent<Rigidbody2D>();
		level = GameObject.Find("Level Control").GetComponent<Level_Control>();
		level.Alive = true;
		Score = GameObject.Find("ScoreGUI").GetComponent<ScoreGUI>();
		//rb2d 값에 물리엔진을 대입
	}
	

	void Update()
	{
		AngletoMouse = Mathf.Rad2Deg * Mathf.Atan2((Mouse_Position.y - transform.position.y), (Mouse_Position.x - transform.position.x)) - 90f;
		//AngleToMouse에 플레이어 기준으로 마우스의 각도를 입력해줌
		//AngleToMouse = arctan(
		Mouse_Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Mouse_Position.z = 0;
		transform.rotation = Quaternion.Euler(0,0,AngletoMouse);
		movement = new Vector2(Mathf.Sin(Mathf.Deg2Rad * AngletoMouse) * (-1), Mathf.Cos(Mathf.Deg2Rad * AngletoMouse));
		if(Score != null)
			score = Score.score;
			/*
			if(Input.GetMouseButtonDown(0){



			}*/
		}
	public void Playermove()
	{
		rb2d.AddForce(movement* speed);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//주요 기능: 자기 자신을 비활성화 한다.
		if (other.transform.gameObject.CompareTag("Enemy Bullet"))
		{
			// 죽는 모션 추가하기

			
			StartCoroutine(Dead());
		}
	}

	IEnumerator Dead() {
		level.Alive = false;
		yield return 0;
	}

	void TransformReset()
	{
		Vector3 a = new Vector3(0, 0, 0);
		gameObject.transform.Rotate(a);
		gameObject.transform.position = a;
	}

}
