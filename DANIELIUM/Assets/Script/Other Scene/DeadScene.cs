using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadScene : MonoBehaviour {

	public Text Died;
	public Text Retry;


	private float t = 0;
	private float a = 0.01f;
	private bool r = false;


	// Use this for initialization
	void Start() {
		Died.color = new Color(255, 0, 0, 0);
		Retry.color = new Color(255, 0, 0, 0);
	}

	// Update is called once per frame
	void Update()
	{
		StartCoroutine(Dead());
		if (0 <= t || t <= 255)
			Died.color = new Color(255, 0, 0, t);
		t += a;
		if (r && Input.anyKeyDown && !Input.GetKeyDown("escape"))
		{
			Destroy(GameObject.Find("Player"));
			SceneManager.LoadScene("TestScene");
		}
		if (r && Input.GetKeyDown("escape"))
		{
			Destroy(GameObject.Find("Player"));
			SceneManager.LoadScene("StartScene");
		}
	}

	IEnumerator Dead()
	{
		yield return new WaitForSeconds(2);
		a = -0.01f;
		yield return new WaitForSeconds(2);
		Died = Retry;
		a = 0.01f;
		yield return new WaitForSeconds(1);
		r = true;
	}


}
