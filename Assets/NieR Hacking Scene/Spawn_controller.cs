using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn_controller : MonoBehaviour {
    public float lvl;
    public Transform[] spawnpoints;
    int[] usedspawnpoints;
    public GameObject[] enemies;
    public int enemy_number;
    public float S_coef;
    public GameObject enemycore;
    public Text text;
    private Core_controller core_script;

    public void killcore() {
        StartCoroutine(killcore_());
    }

    private IEnumerator killcore_() {
        enemycore.SetActive(false);
        text.text = "Stage clear!";
        GameObject _9S = GameObject.Find("9S");
        _9S_controller _9Sscript = _9S.GetComponent<_9S_controller>();
        _9Sscript.enabled = false;

        //cleaning bullets
        GameObject[] playerBullets = GameObject.FindGameObjectsWithTag("bullets");
        CleanGameObjects (playerBullets);
        GameObject[] redBullets = GameObject.FindGameObjectsWithTag("red_bullets");
        CleanGameObjects (redBullets);
        GameObject[] darkBullets = GameObject.FindGameObjectsWithTag ("dark_bullets");
        CleanGameObjects (darkBullets);




        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2f);
        lvl++;
        text.text = "Next level: " + lvl.ToString();
        yield return new WaitForSecondsRealtime(2f);
        start_spawning();
        Time.timeScale = 1;
        _9Sscript.enabled = true;
        text.text = "";
    }
        
    public void CleanGameObjects(GameObject[] objs){
        if (objs.Length != 0) {
            foreach (GameObject obj in objs) {
                Destroy (obj);
            }
        }
    }

    public void start_spawning() {
        core_script.resetCore();
        enemycore.SetActive(true);  
        enemy_number = (int)Mathf.Log(lvl) + 1;
        usedspawnpoints = new int[spawnpoints.Length];
        for (int i = 0; i < usedspawnpoints.Length; i++)
        {
            usedspawnpoints[i] = 0;
        }

        for (int i = 1; i <= enemy_number; i++)
        {
            int ranspawn = Random.Range(0, spawnpoints.Length);
            int ranenemy = Random.Range(0, enemies.Length);
            if (usedspawnpoints[ranspawn] == 0)
            {
                GameObject enemy = Instantiate(enemies[ranenemy], spawnpoints[ranspawn].position, spawnpoints[ranspawn].rotation);
                usedspawnpoints[ranspawn] = 1;
            }
        }

        for (int i = 0; i < usedspawnpoints.Length; i++)
        {
            usedspawnpoints[i] = 0;
        }
    }
	// Use this for initialization
	void Start () {
        core_script = enemycore.GetComponent<Core_controller>();
		text.text = "";
    }
	
	// Update is called once per frame
	void Update () {
        GameObject _9S = GameObject.Find("9S");
        if (_9S == null) {
            text.text = "Game Over";
        }



	}
}
