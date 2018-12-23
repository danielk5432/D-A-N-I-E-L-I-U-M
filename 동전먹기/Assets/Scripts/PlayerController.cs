using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour {

    public AudioClip jumpVoice;
    public AudioClip damageVoice;
	public int Health = 3;


    private AudioSource mAudio;

    private UnityChan2DController mUnityChan2DController;
    private Collider2D mCollider2D;
	// Use this for initialization
	void Start () {
        mAudio = GetComponent<AudioSource>();
        mUnityChan2DController = GetComponent<UnityChan2DController>();
        mCollider2D = GetComponent<Collider2D>();
	}
	
    void OnDamage()
    {
        PlayerVoice(damageVoice);
		
		if (--Health <= 0)
		{
			mCollider2D.enabled = false;
			mUnityChan2DController.enabled = false;
			Game.instance.state = Game.STATE.GAMEOVER;

		}


	}

    void Jump()
    {
        PlayerVoice(jumpVoice);
    }

    void  PlayerVoice(AudioClip clip)
    {
        mAudio.Stop();
        mAudio.PlayOneShot(clip);
    }
	// Update is called once per frame
	void Update () {

	}
}
