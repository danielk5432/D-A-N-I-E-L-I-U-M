using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Pool : MonoBehaviour
{


	public Queue<GameObject> Pooled_Enemy1;
	public Queue<GameObject> Pooled_Enemy2;
	public Queue<GameObject> Pooled_Enemy3;
	public GameObject Enemy1_Template;
	public GameObject Enemy2_Template;
	public GameObject Enemy3_Template;
	public int MAX_POOLED_ENEMY1 = 15;
	public int MAX_POOLED_ENEMY2 = 15;
	public int MAX_POOLED_ENEMY3 = 15;

	Level_Control Count;
	ScoreGUI Score;


	// Use this for initialization
	void Start() 
	{
		Pooled_Enemy1 = new Queue<GameObject>(MAX_POOLED_ENEMY1);
		Pooled_Enemy2 = new Queue<GameObject>(MAX_POOLED_ENEMY2);
		Pooled_Enemy3 = new Queue<GameObject>(MAX_POOLED_ENEMY3);
		Enemy_Load();
		Count = GameObject.Find("Level Control").GetComponent<Level_Control>();
		Score = GameObject.Find("ScoreGUI").GetComponent<ScoreGUI>();
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
				GameObject temp1 = Instantiate(Enemy1_Template);
				GameObject temp2 = Instantiate(Enemy2_Template);
				GameObject temp3 = Instantiate(Enemy3_Template);
				Pooled_Enemy1.Enqueue(temp1);
				Pooled_Enemy2.Enqueue(temp2);
				Pooled_Enemy3.Enqueue(temp3);
				temp1.SetActive(false);
				temp2.SetActive(false);
				temp3.SetActive(false);
			}
		}
		catch
		{
			Debug.Log("Pooling Error has occured!");
		}
	}

	public void Enemy1_Reload(GameObject Enemy)
	{
		Enemy.SetActive(false);
		Pooled_Enemy1.Enqueue(Enemy);
		Count.ECount[0]--;
		Score.score += 100;
	}

	public void Enemy2_Reload(GameObject Enemy)
	{
		Enemy.SetActive(false);
		Pooled_Enemy2.Enqueue(Enemy);
		Count.ECount[1]--;
		Score.score += 300;
	}

	public void Enemy3_Reload(GameObject Enemy)
	{
		Enemy.SetActive(false);
		Pooled_Enemy2.Enqueue(Enemy);
		Count.ECount[2]--;
		Score.score += 1000;
	}
}