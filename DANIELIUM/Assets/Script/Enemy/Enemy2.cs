using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour {

	public float HEALTH_MAXIMUM = 8;
	public bool Alive = false;



	private int Speed = 2;
	private float health;
	private Vector3 PlaceToGo;
	private float AngleToPlace;
	private bool dash = false;
	private float ATP;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Alive)
		{
			if (!dash)
			{
				transform.Rotate(0, 0, ATP + 90);
			}
			if (Mathf.Pow(PlaceToGo.y - transform.position.y, 2) + Mathf.Pow(PlaceToGo.x - transform.position.x, 2) >= Mathf.Pow(Speed, 2))
			{ transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime * Mathf.Cos(Mathf.Deg2Rad * AngleToPlace), transform.position.y + Speed * Time.deltaTime * Mathf.Sin(Mathf.Deg2Rad * AngleToPlace)); }
			else
			{
				health = 0;
			}
		}
		ATP = Mathf.Rad2Deg * Mathf.Atan2((GameObject.Find("Player").transform.position.y - transform.position.y), (GameObject.Find("Player").transform.position.x - transform.position.x));

	}

	public void Init()
	{
		health = HEALTH_MAXIMUM;
		dash = false;
		StartCoroutine(Move());
		Speed = 2;
		Alive = true;
	}

	IEnumerator Move()
	{
		PlaceToGo = GameObject.Find("Player").transform.position;
		AngleToPlace = ATP;
		yield return new WaitForSeconds(2 + Random.Range(-0.1f, 3));
		Speed = 20;
		dash = true;
		PlaceToGo = GameObject.Find("Player").transform.position;
		AngleToPlace = ATP + Random.Range(-15f, 15f);
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
			dash = false;
			GameObject.Find("Level Control").GetComponent<Enemy_Pool>().Enemy1_Reload(gameObject);
		}
	}
}
