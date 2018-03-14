using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemydamege : MonoBehaviour {
    Animator myAmin;

    // Use this for initialization
    void Start() {
        myAmin = GetComponent<Animator>();
        GetComponent<CapsuleCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update() {

    }
    public void Damege(bool b)
    {
        if(b==true)
        {
             GetComponent<CapsuleCollider>().enabled = true;
        }
        else if(b==false)
        {
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }
   void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag== "unitychan")
        {
            GameObject.Find("unitychan").GetComponent<UnityAction>().Life(1);
        }
    }
}
