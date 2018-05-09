using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	private bool paused;
	public GameObject guiController;

	void Start () {
		
	}

	public void Continue(){
		guiController.GetComponent<GUI> ().setPaused(false);
	}

	public void Retry(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void MainMenu(){
		SceneManager.LoadScene("main_menu", LoadSceneMode.Single);
	}
}
