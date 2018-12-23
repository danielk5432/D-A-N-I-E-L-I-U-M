using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uni_0 : MonoBehaviour {
    
    private Collider2D mCollider2D;

    // Use this for initialization
    void Start()
    {
      
        mCollider2D = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Finish")
        {
            Score.instance.Add();
           
            mCollider2D.enabled = false;
            
         
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
