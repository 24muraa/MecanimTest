using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mummyAttack : MonoBehaviour {
    GameObject myTarget;
    Animator myAmin;
    NavMeshAgent myNav;
    bool b;
    float delte = 0;
    public GameObject AttackAura;
    public GameObject lightningPrefub;
    public GameObject attackPoint;
    // Use this for initialization
    void Start () {
        myTarget = GameObject.Find("unitychan");
        myAmin = GetComponent<Animator>();
        myNav = GetComponent<NavMeshAgent>();
        AttackAura.SetActive(false);
    }

    // Update is called once per frame
    void Update () {

        float dist = Vector3.Distance(myTarget.transform.position, transform.position);
        if (dist < 3f)
        {
            myAmin.SetFloat("speed", 0.0f);
            delte += Time.deltaTime;
            attackSign(true);
            if (delte > 4f)
            {
                if (!b)
                {
                    myAmin.SetTrigger("attack");
                    GameObject lightning= Instantiate(lightningPrefub) as GameObject;
                    lightning.transform.position = attackPoint.transform.position;
                    b = true;           
                }

                if (delte > 9.5f)
                {
                    b = false;
                    delte = 0;

                }

            }

        }
        else if (dist > 3f)
        {
            attackSign(false);
        }
    }
    public void attackSign(bool a)
    {
        if (a)
        {
            AttackAura.SetActive(true);
        }
        else if (!a)
        {
            AttackAura.SetActive(false);
        }
    }
}
