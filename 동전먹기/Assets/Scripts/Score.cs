using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private static Score mInstance;

    public static Score instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = FindObjectOfType<Score>();

            }
            return mInstance;
        }
    }

    // Use this for initialization
    void Start()
    {
        if (this != instance)
        {
            Destroy(this);
        }


    }
    public int score
    {
        get;
        private set;
    }

    public void Add()
    {
        score++;
    }

    public void Reset()
    {
        score = 0;
    }
    // Update is called once per frame
    void Update()
    {

    }
}