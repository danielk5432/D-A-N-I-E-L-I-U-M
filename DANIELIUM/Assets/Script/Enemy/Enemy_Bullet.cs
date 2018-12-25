using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour {

	public float Speed;

	private float AngletoPlayer;
	private float speed;

	// Use this for initialization
	void Start () {
	}

	public void init()
	{
		Vector2 PlayerPosition = GameObject.Find("Player").transform.position;
		//AngleToPlace = Mathf.Rad2Deg * Mathf.Atan2((PlaceToGo.y - transform.position.y), (PlaceToGo.x - transform.position.x));
		//Enemy1의 방향 각도 조정 스크립트
		AngletoPlayer = Mathf.Rad2Deg * Mathf.Atan2((PlayerPosition.y - transform.position.y), (PlayerPosition.x - transform.position.x)) + Random.Range(-10f, 10f);
		speed = Speed;
	}

	// Update is called once per frame
	void Update () {
		//transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime * Mathf.Sin(Mathf.Deg2Rad * AngletoMouse), transform.position.y + Speed * Time.deltaTime * Mathf.Cos(Mathf.Deg2Rad * AngletoMouse) * (-1));
		transform.position = new Vector3(transform.position.x + speed * Time.deltaTime * Mathf.Cos(Mathf.Deg2Rad * AngletoPlayer), transform.position.y + Speed * Time.deltaTime * Mathf.Sin(Mathf.Deg2Rad * AngletoPlayer));
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//주요 기능: 자기 자신을 비활성화 한다.
		if (other.transform.gameObject.CompareTag("BulletCollider") || other.transform.gameObject.CompareTag("Player"))
		{
			GameObject.Find("Level Control").GetComponent<Enemy_Bullet_Pool>().Enemy1_Reload(gameObject);
			speed = 0;
		}
		//주요 기능 구현 후 아래 문제를 고려해봅시다.
		//다른 총알의 Collider와 충돌한 경우를 판정할 수 있나요?
		//Hint: collision.transform.gameObject.tag를 통해 충돌한 Collider를 Component로 가지고 있는 오브젝트의 Tag를 확인할 수 있다.
	}
}
