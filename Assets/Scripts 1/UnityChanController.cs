using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //マウスがクリックされた場合
        if (Input.GetMouseButtonDown(0))
        {
            //Animatorコンポーメントを取得し、"jumpTrigger"をtrueにする
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        }
	}
}
