using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerKeyboardInputScript : MonoBehaviour {

	public string[] iCanFarmPP;
	public string[] remoteControl;
	public string[] thisIsMario;
	
	public int ppIndex;
	public int remoteIndex;
	public int marioIndex;

	public GameObject allLvsCompleted;

	public loadLvl loadScript;

	void Start() {
		iCanFarmPP = new string[] { "i", "space", "c", "a", "n", "space", "f", "a", "r", "m", "space", "p", "p" };
		remoteControl = new string[] { "left", "right", "left", "right", "s", "d", "up", "t", "b", "b", "a", "b", "s"};
		thisIsMario = new string[] { "t", "h", "i", "s", "space", "i", "s", "space", "m", "a", "r", "i", "o"};
		
		ppIndex = 0;
		remoteIndex = 0;
		marioIndex = 0;
		
		if(PlayerPrefs.GetInt("allLvlsUnlocked") == 1)
			allLvsCompleted.SetActive(true);
	}

	void Update() {
		// Check if any key is pressed
		if (Input.anyKeyDown) {
			if (Input.GetKeyDown(iCanFarmPP[ppIndex])) {
				ppIndex++;
			}
			else {
				ppIndex = 0;    
			}
			
			if (Input.GetKeyDown(remoteControl[remoteIndex])) {
				remoteIndex++;
			}
			else {
				remoteIndex = 0;    
			}
			
			if (Input.GetKeyDown(thisIsMario[marioIndex])) {
				marioIndex++;
			}
			else {
				marioIndex = 0;    
			}
		}

		// If index reaches the length of the cheatCode string, 
		// the entire code was correctly entered
		if (ppIndex == iCanFarmPP.Length) {
			loadScript.loadScene ("icanfarmpp");
			ppIndex = 0;
		}
		
		if (remoteIndex == remoteControl.Length) {
			loadScript.loadScene ("icanremotecontrol");
			remoteIndex = 0;
		}
		
		if (marioIndex == thisIsMario.Length) {
			PlayerPrefs.SetInt("allLvlsUnlocked", 1);
			allLvsCompleted.SetActive(true);
			marioIndex = 0;
		}
	}
}
