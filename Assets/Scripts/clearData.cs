using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clearData : MonoBehaviour {

	public void ClearData(){
		PlayerPrefs.DeleteAll();
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
