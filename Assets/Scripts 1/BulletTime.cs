using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTime : MonoBehaviour {
    private float time;  //弾の寿命
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //float変数 timeに時間を代入
        time += Time.deltaTime;
       //時間が経過したら弾が消滅
        if (time >= 0.15f)
        {
            Destroy(gameObject);
        }
    }
}
