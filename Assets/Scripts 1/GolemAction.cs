using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GolemAction : MonoBehaviour {
    GameObject myTarget;
    NavMeshAgent myNav;
    Animator myAmin;
    int n = 100;
    private Enemygenerator eg;

    // Use this for initialization
    void Start () {
        myNav = GetComponent<NavMeshAgent>();
        myTarget = GameObject.Find("unitychan");
        myAmin = GetComponent<Animator>();
        eg = GameObject.Find("Enemycontroller").GetComponent<Enemygenerator>();
        GetComponent<CapsuleCollider>().enabled = true;

    }

    // Update is called once per frame
    void Update () {
        myNav.destination = myTarget.transform.position;
        myAmin.SetFloat("speed", myNav.velocity.magnitude);
	}
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            n--;
            string s = "" + n;
            Destroy(other.gameObject);
            if (n <= 0)
            {
                GetComponent<CapsuleCollider>().enabled = false;
                myAmin.SetTrigger("die");
                Destroy(gameObject, 2f);
                eg.DecreseEnemy();
                myNav.Stop();

            }
        }
    }
}
