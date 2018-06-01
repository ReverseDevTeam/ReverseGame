using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardModeBtn : MonoBehaviour {

	public Button hardBtn;
	public GameObject hardModeBG;


	void Start(){
		PlayerPrefs.SetInt ("reversedOn", 0);
	}

	void LateUpdate () {
		if (PlayerPrefs.GetInt("lvl6_complete") == 1 || PlayerPrefs.GetInt("allLvlsUnlocked") == 1){
			hardBtn.interactable = true;
		} else {
			hardBtn.interactable = false;
		}

		if (PlayerPrefs.GetInt ("reversedOn") == 0) {
			hardModeBG.SetActive (false);
		} else if (PlayerPrefs.GetInt("reversedOn") == 1){
			hardModeBG.SetActive (true);
		}
	}

	public void PushBtn(){
		if (PlayerPrefs.GetInt("reversedOn") == 0) {
			PlayerPrefs.SetInt ("reversedOn", 1);
		} else if (PlayerPrefs.GetInt("reversedOn") == 1) {
			PlayerPrefs.SetInt ("reversedOn", 0);
		}
	}
}