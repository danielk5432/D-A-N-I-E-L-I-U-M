using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverScrene : MonoBehaviour {
   
    private Collider2D mcollider2D;
	// Use this for initialization
	void Start () {
        mcollider2D = GetComponent<Collider2D>();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            AsyncOperation async;
            async = SceneManager.LoadSceneAsync("PlayScene");
            
        }
              
    }
    // Update is called once per frame
    void Update () {
		
	}
}
