using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet: MonoBehaviour
{

	public float Speed;

	private float Summon_Time;
	// Use this for initialization
	void Start()
	{

	}



	private void OnTriggerEnter2D(Collider2D collision)
	{
		//주요 기능: 자기 자신을 비활성화 한다.


		//주요 기능 구현 후 아래 문제를 고려해봅시다.
		//다른 총알의 Collider와 충돌한 경우를 판정할 수 있나요?
		//Hint: collision.transform.gameObject.tag를 통해 충돌한 Collider를 Component로 가지고 있는 오브젝트의 Tag를 확인할 수 있다.
	}

	// Update is called once per frame
	void Update()
	{
	
		transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime, transform.position.y);
	}
	public void Time_Limit()
	{
		Summon_Time = Time.fixedTime;
	}

}
