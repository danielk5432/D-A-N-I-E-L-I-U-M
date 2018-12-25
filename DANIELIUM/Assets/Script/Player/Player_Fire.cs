using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Fire : MonoBehaviour
{
	
	Queue<GameObject> Pooled_Bullet;
	public GameObject Bullet_Template;
	public int MAX_POOLED_BULLET = 300;
	public float FIRE_INTERVAL = 0.5f;//한발 발사하는데 얼마나 걸리나용
	public float Attack = 10;


	private bool Is_Fire;//발사중인가요?
	private float Last_Fire_Time;


	// Use this for initialization
	void Start()
	{
		Pooled_Bullet = new Queue<GameObject>(MAX_POOLED_BULLET);
		Bullet_Load();
		Last_Fire_Time = Time.fixedTime;
		Is_Fire = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Fire_Toggle();
		}
		if (Input.GetMouseButtonUp(0))
		{
			Fire_Toggle();
		}

		if (Is_Fire)
		{
			if (Time.fixedTime - Last_Fire_Time >= FIRE_INTERVAL)
			{
				Last_Fire_Time = Time.fixedTime;
				GameObject proj = Pooled_Bullet.Dequeue();
				if (proj != null)
				{
					proj.SetActive(true);
					proj.transform.position = transform.position;
					proj.GetComponent<Bullet>().init();
					GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Move>().Playermove();
				}
			}
		}
		//Object Counting
		//var Active_Bullet = GameObject.FindGameObjectsWithTag("Bullet");
		//Debug.Log(Active_Bullet.Length);
		//BulletCount.text = Active_Bullet.Length.ToString();
	}


	public void Fire_Toggle()
	{
		Is_Fire = !Is_Fire;
	}



	//최초에 단 한번 오브젝트를 Pooling하는 함수입니다.
	private void Bullet_Load()
	{
		try
		{
			for (int i = 0; i < MAX_POOLED_BULLET; i++)
			{
				GameObject temp = Instantiate(Bullet_Template);
				Pooled_Bullet.Enqueue(temp);
				temp.SetActive(false);
			}
		}
		catch
		{
			Debug.Log("Pooling Error has occured!");
		}
	}



	//++해도 되고 안해도 되는 과제
	//이 함수는 완전하지 않은 함수입니다. 어떻게 하면 고칠 수 있을까요?
	public void Bullet_Reload(GameObject Bullet)
	{
		//Bullet 오브젝트가 충돌하면 그 오브젝트에서 이 함수를 호출한다.(스크립트 외부에서 호출한다)
		//이 함수를 호출할 때 인자로써는 Script가 붙어있는 GameObject를 전달한다.

		//충돌한 오브젝트를 비활성화 하고 오브젝트 풀에 다시 넣는다.
		Bullet.SetActive(false);
		Pooled_Bullet.Enqueue(Bullet);
	}
}

