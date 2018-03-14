using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAction : MonoBehaviour {
    GameObject myTarget;　　　　//追いかける対象
    NavMeshAgent myNav;　　　　 //ナビメッシュ
    Animator myAmin;　　　　　　//アニメーション
    public int HP = 100;        //敵の体力
    private Enemygenerator eg;  //Enemygenerator
    private EnemyAttack ea;     //EnemyAttack
    // Use this for initialization
    void Start () {
        //myNavにNavMeshAgentを取得させる
        myNav = GetComponent<NavMeshAgent>();
        //myTargetにユニティちゃんの情報を代入
        myTarget = GameObject.Find("unitychan");
        //myAminにAnimatorを取得させる
        myAmin = GetComponent<Animator>();
        //egにEnemycontrollerのEnemygeneratorを取得させる
        eg = GameObject.Find("Enemycontroller").GetComponent<Enemygenerator>();
        //このオブジェクトのコライダーを機能させる
        GetComponent<CapsuleCollider>().enabled = true;
        //eaにこのオブジェクトに取得しているEnemyAttackを取得させる
        ea=this.gameObject.GetComponent<EnemyAttack>();
    }

    // Update is called once per frame
    void Update () {
        //プレイヤーを追いかける
        myNav.destination = myTarget.transform.position;
        myAmin.SetFloat("sped", myNav.velocity.magnitude);
        if (HP <= 0)
        {
            return;
        }
	}
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            HP--;
            Destroy(other.gameObject);
            if (HP <= 0)
            {
                GetComponent<CapsuleCollider>().enabled = false;
                myAmin.SetTrigger("die");
                Destroy(gameObject, 3f);
                eg.DecreseEnemy();
                ea.dieSign();
                myNav.Stop();
            }
        }
    }
}
