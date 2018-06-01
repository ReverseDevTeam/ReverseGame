using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour {
	
	void Update()
	{
	    if(Input.GetKeyDown(KeyCode.Escape))
		    MainMenu();
	}
	
	public void Quit(){
		Application.Quit ();
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("main_menu");
	}

}
