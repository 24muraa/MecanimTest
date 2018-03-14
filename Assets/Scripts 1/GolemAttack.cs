using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GolemAttack : MonoBehaviour {
    GameObject myTarget;
    Animator myAmin;
    NavMeshAgent myNav;
    bool b;
    float delte = 0;
    public GameObject AttackAura;
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
            if (delte > 7f)
            {
                int ran = Random.Range(0, 9);
                if (ran >= 4)
                {
                    if (!b)
                    {
                        myAmin.SetTrigger("attack");
                        GameObject.Find("R").GetComponent<GolemdamegeR>().Damege(true);
                        b = true;
                    }
                    if (delte > 9.5f)
                    {
                        b = false;
                        GameObject.Find("R").GetComponent<GolemdamegeR>().Damege(false);
                        delte = 0;
                    }

                }
                else
                {
                    if (!b)
                    {
                        myAmin.SetTrigger("attack2");
                        GameObject.Find("L").GetComponent<GolemdamegeL>().Damege(true);
                        b = true;
                    }
                    if (delte > 9.5f)
                    {
                        b = false;
                        GameObject.Find("L").GetComponent<GolemdamegeL>().Damege(false);
                        delte = 0;
                    }

                }

            }

        }
        else if (dist > 2f)
        {
            attackSign(false);
        }
    }
    void attackSign(bool a)
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
