using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour {

	public float speed;
	Vector3 Mouse_Position;
	private Rigidbody2D rb2d;
	Vector2 movement;

	public float AngletoMouse;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
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

		/*
		if(Input.GetMouseButtonDown(0){



		}*/
	}
	public void Playermove()
	{
		rb2d.AddForce(movement* speed );
	}


}
