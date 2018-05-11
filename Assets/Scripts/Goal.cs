using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

	public string sceneName;
	public int here;
	
	public GameObject lvlCompleteUI;

	void Start ()
	{
		sceneName = SceneManager.GetActiveScene().name;
	}

	void Update () {

	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			Debug.Log("Finish!");
			Destroy (GetComponent<BoxCollider2D>());
			PlayerPrefs.SetInt (sceneName + "_complete", 1);
			lvlCompleteUI.SetActive(true);
		}
	}
}