using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet_Pool : MonoBehaviour {

	public Queue<GameObject> EPooled_Bullet;
	public GameObject EBullet_Template;
	public int MAX_POOLED_EBULLET = 300;


	// Use this for initialization
	void Start () {
		EPooled_Bullet = new Queue<GameObject>(MAX_POOLED_EBULLET);
		Bullet_Load();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void Bullet_Load()
	{
		try
		{
			for (int i = 0; i < MAX_POOLED_EBULLET; i++)
			{
				GameObject temp = Instantiate(EBullet_Template);
				EPooled_Bullet.Enqueue(temp);
				temp.SetActive(false);
			}
		}
		catch
		{
			Debug.Log("Pooling Error has occured!");
		}
	}

	public void Enemy1_Reload(GameObject EBullet)
	{
		//Bullet 오브젝트가 충돌하면 그 오브젝트에서 이 함수를 호출한다.(스크립트 외부에서 호출한다)
		//이 함수를 호출할 때 인자로써는 Script가 붙어있는 GameObject를 전달한다.

		//충돌한 오브젝트를 비활성화 하고 오브젝트 풀에 다시 넣는다.
		EBullet.SetActive(false);
		EPooled_Bullet.Enqueue(EBullet);
	}

	public void EFire1(Vector3 pos)
	{
		GameObject proj = EPooled_Bullet.Dequeue();
		proj.SetActive(true);
		proj.transform.position = pos;
		proj.GetComponent<Enemy_Bullet>().init();
	}
}
