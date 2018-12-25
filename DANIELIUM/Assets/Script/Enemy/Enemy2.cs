using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour {

	public float HEALTH_MAXIMUM = 8;



	private int Speed = 2;
	private float health;
	private Vector3 PlaceToGo;
	private float AngleToPlace;
	private float ATP;


	public enum STATE
	{
		MOVE,
		DASH,
		BACK
	};
	public STATE state
	{
		get;
		set;
	}

	// Use this for initialization
	void Start () {
		
	}

	
	// Update is called once per frame
	void Update () {

		switch (state)
		{
			case STATE.MOVE:
				transform.Rotate(0, 0, ATP + 90 - transform.eulerAngles.z);
				break;
			case STATE.DASH:
				if (Mathf.Pow(PlaceToGo.y - transform.position.y, 2) + Mathf.Pow(PlaceToGo.x - transform.position.x, 2) <= 1)
				{
					state = STATE.BACK;
				}
				break;
			case STATE.BACK:
				transform.Rotate(0, 0, ATP + 90 - transform.eulerAngles.z);
				break;

		}
		if (Mathf.Pow(PlaceToGo.y - transform.position.y, 2) + Mathf.Pow(PlaceToGo.x - transform.position.x, 2) >= 1)
		{ transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime * Mathf.Cos(Mathf.Deg2Rad * AngleToPlace), transform.position.y + Speed * Time.deltaTime * Mathf.Sin(Mathf.Deg2Rad * AngleToPlace)); }


		/*if (Alive)
		{
			if (!dash)
			{
				transform.Rotate(0, 0, ATP + 90 - transform.eulerAngles.z);
			}
			if (Mathf.Pow(PlaceToGo.y - transform.position.y, 2) + Mathf.Pow(PlaceToGo.x - transform.position.x, 2) >= 1)
			{ transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime * Mathf.Cos(Mathf.Deg2Rad * AngleToPlace), transform.position.y + Speed * Time.deltaTime * Mathf.Sin(Mathf.Deg2Rad * AngleToPlace)); }
			else
			{
				health = 0;
			}
		}*/
		ATP = Mathf.Rad2Deg * Mathf.Atan2((GameObject.Find("Player").transform.position.y - transform.position.y), (GameObject.Find("Player").transform.position.x - transform.position.x));

	}
	public void Init()
	{
		health = HEALTH_MAXIMUM;
		state = STATE.MOVE;
		StartCoroutine(Move());
		Speed = 2;
	}

	IEnumerator Move()
	{
		while (true)
		{
			PlaceToGo = GameObject.Find("Player").transform.position;
			AngleToPlace = Mathf.Rad2Deg * Mathf.Atan2((PlaceToGo.y - transform.position.y), (PlaceToGo.x - transform.position.x));
			Debug.Log(PlaceToGo.x);
			Debug.Log(PlaceToGo.y);
			Debug.Log(AngleToPlace);
			yield return new WaitForSeconds(2 + Random.Range(-0.1f, 3));
			Speed = 10;
			state = STATE.DASH;
			PlaceToGo = GameObject.Find("Player").transform.position;
			AngleToPlace = ATP;
			while (state == STATE.DASH)
				yield return 0;
			PlaceToGo = new Vector3(PlaceToGo.x + 100 * Mathf.Cos(Mathf.Deg2Rad * AngleToPlace), PlaceToGo.y + 100 * Mathf.Sin(Mathf.Deg2Rad * AngleToPlace));
			while (state == STATE.BACK)
				yield return 0;
			Speed = 2;
			PlaceToGo = transform.position;
			yield return new WaitForSeconds(2 + Random.Range(-0.1f, 3));
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
			GameObject.Find("Level Control").GetComponent<Enemy_Pool>().Enemy2_Reload(gameObject);
		}
		if (other.transform.gameObject.CompareTag("EnemyCollider") && state == STATE.BACK)
		{
			state = STATE.MOVE;
		}
	}
}
