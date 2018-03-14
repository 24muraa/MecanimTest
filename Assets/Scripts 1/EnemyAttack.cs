using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour {
    GameObject myTarget;
    Animator myAmin;
    NavMeshAgent myNav;
    bool b;
    float delte = 0;
    bool c;
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
        if (c)
        {
            return;
        }
        float dist = Vector3.Distance(myTarget.transform.position, transform.position);
        if (dist < 3f)
        {
            myAmin.SetFloat("sped", 0.0f);
            delte += Time.deltaTime;
            attackSign(true);
            if (delte > 4f)
            {
                if (!b)
                {
                    myAmin.SetTrigger("attack");
                    GameObject.Find("Axe").GetComponent<Enemydamege>().Damege(true);

                    b = true;           
                }

                if (delte > 9.5f)
                {
                    b = false;
                    GameObject.Find("Axe").GetComponent<Enemydamege>().Damege(false);

                    delte = 0;

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
    public void dieSign()
    {
        c = true;
    }
}
