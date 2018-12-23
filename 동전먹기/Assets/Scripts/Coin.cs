using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class Coin : MonoBehaviour {

    private AudioSource mAudio;
    private Renderer mRenderer;
    private Collider2D mCollider2D;

	// Use this for initialization
	void Start () {
        mAudio = GetComponent<AudioSource>();
        mRenderer = GetComponent<Renderer>();
        mCollider2D = GetComponent<Collider2D>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Score.instance.Add();
            mRenderer.enabled = false;
            mCollider2D.enabled = false;
            mAudio.Play();
            Destroy(gameObject, mAudio.clip.length);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
