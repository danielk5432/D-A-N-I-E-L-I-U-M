using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {
    private Collider2D mcollider2D;
    // Use this for initialization
    void Start()
    {
        
        mcollider2D = GetComponent<Collider2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.name == "Finish")
        {
            Application.Quit();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
