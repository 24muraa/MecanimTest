using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.SceneManagement;

public class UnityAction : MonoBehaviour {

    private Animator myAnim;
    private Slider slider;
    public float hp = 10f;
	// Use this for initialization
	void Start () {
        this.myAnim = GetComponent<Animator>();
        slider = GameObject.Find("Slider").GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            myAnim.SetBool("shoot", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            myAnim.SetBool("shoot", false);
        }
	}
    public void Life(float damege)
    {
        hp = hp - damege;
        slider.value = hp;
        if (slider.value <= 0)
        {
            SceneManager.LoadScene("lose");
            GetComponent<ThirdPersonUserControl>().enabled = false;
        }
    }
}
