using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightning : MonoBehaviour {
    private float time;  //弾の寿命
                         // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //float変数 timeに時間を代入
        time += Time.deltaTime;
        //時間が経過したら弾が消滅
        if (time >= 0.5f)
        {
            Destroy(gameObject);
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name== "unitychan")
        {
            Debug.Log(1);
            Destroy(gameObject);
            GameObject.Find("unitychan").GetComponent<UnityAction>().Life(1);
        }
    }
}
