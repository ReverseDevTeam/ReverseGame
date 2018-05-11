using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Easter : MonoBehaviour {

	public int numClick;
	public GameObject menu;
	public GameObject text;

	void Start () {
		numClick = 0;
		text.SetActive (false);
	}

	public void Click(){
		numClick ++;
		if (numClick == 20) {
			menu.SetActive (false);
			text.SetActive (true);
			numClick = 0;
		}
	}
}
