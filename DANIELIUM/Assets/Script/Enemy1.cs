using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour {



	public int Speed = 4;


	private Vector3 PlaceToGo;
	private float AngleToPlace;


	// Use this for initialization
	void Start () {
		StartCoroutine(Fire());
		StartCoroutine(Move());
	}
	
	// Update is called once per frame
	void Update () {

		//transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime * Mathf.Sin(Mathf.Deg2Rad * AngletoMouse), transform.position.y + Speed * Time.deltaTime * Mathf.Cos(Mathf.Deg2Rad * AngletoMouse) * (-1));
		//총알의 스크립트
		//반대로 나감
		if ( Mathf.Pow(PlaceToGo.y - transform.position.y, 2) + Mathf.Pow(PlaceToGo.x - transform.position.x, 2) >= Mathf.Pow(Speed, 2)/4 )
		{ transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime * Mathf.Cos(Mathf.Deg2Rad * AngleToPlace), transform.position.y + Speed * Time.deltaTime * Mathf.Sin(Mathf.Deg2Rad * AngleToPlace)); }


	}

	IEnumerator Fire()
	{
		while (true)
		{

			//총알 발사 스크립트 작성

			yield return new WaitForSeconds(3);
			/*if(비활성화)
			  {break;}
			  아니면 while문 바꾸기*/
		}
	}

	IEnumerator Move()
	{
		while (true)
		{
			//움직이는 것 스크립트 작성
			PlaceToGo = new Vector3(Random.Range(10f, -10f), Random.Range(5f, -5f));

			Debug.Log(PlaceToGo);

			AngleToPlace = Mathf.Rad2Deg * Mathf.Atan2((PlaceToGo.y - transform.position.y), (PlaceToGo.x - transform.position.x));
			//AngletoMouse = Mathf.Rad2Deg * Mathf.Atan2((Mouse_Position.y - transform.position.y), (Mouse_Position.x - transform.position.x)) - 90f;

			Debug.Log(AngleToPlace);

			yield return new WaitForSeconds(4);
			/*if(비활성화)
				  {break;}
			아니면 while문 바꾸기*/
		}
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
