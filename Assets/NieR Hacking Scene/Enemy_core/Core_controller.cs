using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Core_controller : MonoBehaviour {
    
    public float hp;
    private float originHp;
    public Transform trans0;
    public Transform trans1;
    public GameObject[] projectile;
    public float firerate;
    public float nextfire;
    public Transform player;
    public GameObject shield;
    private Transform shieldTrans;
    private Transform coreTrans;
    private float time;
    public float movetoward;
    public GameObject spawncontroller;
    private Spawn_controller spawn_controller;
    private bool invincible;


	// Use this for initialization
	void Start () {
        coreTrans = GetComponent<Transform> ();
        shieldTrans = shield.GetComponent<Transform> ();
        spawn_controller = spawncontroller.GetComponent<Spawn_controller>();
        invincible = true;
        originHp = hp;
	}

    // Update is called once per frame
    public void dead() {
        spawn_controller.killcore();
    }

    public void takedmg()
    {
        if (invincible == false) {
                hp -= 25;
            if (hp <= 0)
                dead ();
        }
    }

    // reset the invincibility and hp. This should be called after each level
    public void resetCore()
    {
        this.invincible = true;
        this.hp = originHp;
    }

	void Update () {

        //Players have to kill minions first before they can deal damage to the core. 
        if (GameObject.Find ("minion_1(Clone)") == null) { // I think finding tag should be better here if we tag all minions
            invincible = false;
        } else {
            invincible = true;
        }

        if (Time.time > nextfire) {
            nextfire = Time.time + firerate;
            int ran = Random.Range(0, 2);
            int ran2 = Random.Range(0, 2);
            GameObject bullet0 = Instantiate(projectile[ran], trans0.position, trans0.rotation) as GameObject;
            GameObject bullet1 = Instantiate(projectile[ran2], trans1.position, trans1.rotation) as GameObject;

            bullet0.GetComponent<Rigidbody2D>().AddForce(-trans0.up * 450);
            bullet1.GetComponent<Rigidbody2D>().AddForce(trans1.up * 450);
        }


        if (player != null) {
            Vector2 direction = Vector2.MoveTowards(transform.position, player.position, movetoward);
            if (time >= 3f)
            {
                movetoward = -movetoward;
                time = 0f;
            }
            else {
                time += 1f * Time.deltaTime;
            }
            transform.position = direction;
        } 

        // Control shield
        shieldTrans.position = coreTrans.position;
        if (invincible) {
            shield.SetActive (true);
        } else {
            shield.SetActive (false);
        }

    }

    // This method is used to check invincibility of the enemy core
    public bool IsInvincible()
    {
        return invincible;
    }
}
