using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour {



	void Start () {

	}

	void Update () {
		
	}

	public void Retry(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void MainMenu(){
		SceneManager.LoadScene("main_menu", LoadSceneMode.Single);
	}
}
