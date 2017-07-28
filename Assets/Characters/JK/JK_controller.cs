using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_controller : MonoBehaviour {
    Animator anim;
    Rigidbody2D rigid;
	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float getaxis = Input.GetAxis("Vertical");
        rigid.velocity = new Vector2(rigid.velocity.x, getaxis * 3);
        if (getaxis!=0)
        {
            anim.SetBool("walking", true);
        }
        else {
            anim.SetBool("walking", false);
        }
	}
}
