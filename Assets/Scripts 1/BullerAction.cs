using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BullerAction : MonoBehaviour {
    public float force = 0;
    public GameObject pistol;
    Color ColorY = new Color(0.8f, 0.8f, 0, 1.0f);
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            // 丸いSphereを生成している
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

            sphere.tag = "Ball";
            sphere.GetComponent<Renderer>().material.color = ColorY;

            // 生成した直後の座標
            sphere.transform.position = pistol.transform.position;
            //生成した弾のサイズ
            sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

            // BallというScriptをアタッチしている
            sphere.AddComponent<BulletTime>();

            // Rigidbodyをアタッチしている
            Rigidbody rig = sphere.AddComponent<Rigidbody>();
            
            // 重力を無効にする
            rig.useGravity = false;

            // 力を加えて飛ばせる為
            rig.AddForce(this.transform.forward * force);
            
        }
    }
}
