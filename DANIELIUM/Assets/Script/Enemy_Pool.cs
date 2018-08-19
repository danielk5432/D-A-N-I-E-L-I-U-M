using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Pool : MonoBehaviour
{


	public Queue<GameObject> Pooled_Enemy1;
	public GameObject Enemy1_Template;
	public int MAX_POOLED_ENEMY1 = 40;

	// Use this for initialization
	void Start() 
	{
		Pooled_Enemy1 = new Queue<GameObject>(MAX_POOLED_ENEMY1);
		Enemy_Load();
	}

	// Update is called once per frame
	void Update()
	{

	}



	private void Enemy_Load()
	{
		try
		{
			for (int i = 0; i < MAX_POOLED_ENEMY1; i++)
			{
				GameObject temp = Instantiate(Enemy1_Template);
				Pooled_Enemy1.Enqueue(temp);
				temp.SetActive(false);
			}
		}
		catch
		{
			Debug.Log("Pooling Error has occured!");
		}
	}

	public void Enemy1_Reload(GameObject Enemy)
	{
		//Bullet 오브젝트가 충돌하면 그 오브젝트에서 이 함수를 호출한다.(스크립트 외부에서 호출한다)
		//이 함수를 호출할 때 인자로써는 Script가 붙어있는 GameObject를 전달한다.

		//충돌한 오브젝트를 비활성화 하고 오브젝트 풀에 다시 넣는다.
		Enemy.SetActive(false);
		Pooled_Enemy1.Enqueue(Enemy);
	}
}