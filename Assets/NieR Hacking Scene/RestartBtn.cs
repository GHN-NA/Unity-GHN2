using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartBtn : MonoBehaviour {

	private Button restartBtn;
	private void Start()
	{
		restartBtn = GetComponent<Button>();
		restartBtn.gameObject.SetActive(false);
	}

	// for some reasons, this doesnt work
	//private void Update () {
	//	if (player == null)	// the player is destroyed
	//	{
	//		restartBtn.gameObject.SetActive(true);
	//	}
	//}

	public void LoadScene()
	{
		SceneManager.LoadScene("NieR Hacking game");
	}

}
