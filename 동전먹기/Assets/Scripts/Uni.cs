using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uni : MonoBehaviour {
    private Collider2D mCollider2;
    public GameObject prefab;
    public Vector3 randomPosRange = Vector3.up;
    public Vector3 velocity = Vector3.left;
    public float offsetTime = 0f;
    public float intervalTime = 3f;
    public float leftTime = 5f;
    public float mTime = 0f;
    // Use this for initialization
    void Start()
    {
        mTime = -offsetTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Game.instance.state != Game.STATE.MOVE)
        {
            return;
        }

        mTime += Time.deltaTime;

        if (mTime < 0f)
        {
            return;
        }
        if (mTime >= intervalTime)
        {
            Vector3 randomPos = Vector3.one;
            randomPos.x = Random.Range(-randomPosRange.x, randomPosRange.x);
            randomPos.y = Random.Range(-randomPosRange.y, randomPosRange.y);

            Vector3 pos = transform.position + randomPos;

            GameObject obj = Instantiate(prefab, pos, transform.rotation) as GameObject;

            obj.GetComponent<Rigidbody2D>().velocity = velocity;

            Destroy(obj, leftTime);        
            
            
            

            

            mTime = 0f;
        }

    }
}
