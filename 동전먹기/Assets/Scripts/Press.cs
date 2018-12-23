using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Press : MonoBehaviour {
    public string nextSceneName;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown)
        {
            Application.LoadLevel(nextSceneName);
        }
	}
}
