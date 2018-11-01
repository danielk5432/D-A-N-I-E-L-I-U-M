using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour {

	Enemy_Bullet_Pool EFire;
	public float HEALTH_MAXIMUM = 25;
	public int Speed = 4;
	public bool Alive = false;


	private float health;
	private Vector3 PlaceToGo;
	private float AngleToPlace;

	void Start()
	{
		EFire = GameObject.Find("Level Control").GetComponent<Enemy_Bullet_Pool>();
	}

	// Use this for initialization
	public void Init () {
		health = HEALTH_MAXIMUM;
		Alive = true;
		StartCoroutine(Fire());
		StartCoroutine(Move());
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameObject.Find("Level Control").GetComponent<Level_Control>().Alive)
		{
			gameObject.SetActive(false);
		}
		if (Alive)
		{
			//transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime * Mathf.Sin(Mathf.Deg2Rad * AngletoMouse), transform.position.y + Speed * Time.deltaTime * Mathf.Cos(Mathf.Deg2Rad * AngletoMouse) * (-1));
			//총알의 스크립트
			//반대로 나감
			if (Mathf.Pow(PlaceToGo.y - transform.position.y, 2) + Mathf.Pow(PlaceToGo.x - transform.position.x, 2) >= Mathf.Pow(Speed, 2) / 4)
			{ transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime * Mathf.Cos(Mathf.Deg2Rad * AngleToPlace), transform.position.y + Speed * Time.deltaTime * Mathf.Sin(Mathf.Deg2Rad * AngleToPlace)); }

		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//주요 기능: 자기 자신을 비활성화 한다.
		if (other.transform.gameObject.CompareTag("Bullet"))
		{
			health -= GameObject.Find("Player").GetComponent<Player_Fire>().Attack;
		}
		if (health <= 0)
		{
			Alive = false;
			GameObject.Find("Level Control").GetComponent<Enemy_Pool>().Enemy1_Reload(gameObject);
		}
		//주요 기능 구현 후 아래 문제를 고려해봅시다.
		//다른 총알의 Collider와 충돌한 경우를 판정할 수 있나요?
		//Hint: collision.transform.gameObject.tag를 통해 충돌한 Collider를 Component로 가지고 있는 오브젝트의 Tag를 확인할 수 있다.
	}

	IEnumerator Fire()
	{
		yield return new WaitForSeconds(3);
		while (Alive)
		{
			//총알 발사 스크립트 작성
			EFire.EFire1(transform.position);

			float a = Random.Range(0.0f, 4.0f);
			yield return new WaitForSeconds(4 + a);
		}
	}

	IEnumerator Move()
	{
		while (Alive)
		{
			//움직이는 것 스크립트 작성
			PlaceToGo = new Vector3(Random.Range(9f, -9f), Random.Range(5f, -5f));

			//Debug.Log(PlaceToGo);

			AngleToPlace = Mathf.Rad2Deg * Mathf.Atan2((PlaceToGo.y - transform.position.y), (PlaceToGo.x - transform.position.x));
			//AngletoMouse = Mathf.Rad2Deg * Mathf.Atan2((Mouse_Position.y - transform.position.y), (Mouse_Position.x - transform.position.x)) - 90f;

			//Debug.Log(AngleToPlace);

			float a = Random.Range(-0.5f, 0.5f);
			yield return new WaitForSeconds(4 + a);
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
