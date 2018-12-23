using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {
    
    private static Game mInstance;
    
    

    public static Game instance
    {
        get
        {
            if(mInstance == null)
            {
                mInstance = FindObjectOfType<Game>();
            }
            return mInstance;

        }
    }
    public enum STATE
    {
        NONE,
        START,
        MOVE,
        GAMEOVER
     
    };
    public STATE state
    {
        get;
        set;
    }
    private Text mText;
	// Use this for initialization
	void Start () {
        mText = GetComponent<Text>();
        
        state = STATE.START;
        StartCoroutine("StartCountDown");

        
	}

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case STATE.START:
                break;
            case STATE.MOVE:
                break;
            case STATE.GAMEOVER:
                mText.text = "Game Over";
                AsyncOperation async;
                async = SceneManager.LoadSceneAsync("GameOverScene");
                
                break;
        }
    }
	
    IEnumerator StartCountDown()
    {
        mText.text = "3";

        yield return new WaitForSeconds(1.0f);

        mText.text = "2";

        yield return new WaitForSeconds(1.0f);

        mText.text = "1";

        yield return new WaitForSeconds(1.0f);

        mText.text = "";

        state = STATE.MOVE;
    }
}
