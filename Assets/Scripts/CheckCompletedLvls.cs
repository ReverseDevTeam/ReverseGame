using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCompletedLvls : MonoBehaviour {

	public List<Button> lvlButtons = new List<Button>();

	// Use this for initialization
	void Start () {

		for (int i = 1; i <= 6; i++) 
		{
			lvlButtons.Add((GameObject.Find("/Canvas/fd/LevelSelect/" + i).GetComponent<Button>()));
		}

		lvlButtons[0].interactable = true;

		for (int i = 1; i <= 6; i++) 
		{
			if (PlayerPrefs.GetInt ("lvl" + i + "_complete") == 1 || PlayerPrefs.GetInt("allLvlsUnlocked") == 1) {
				lvlButtons [i].interactable = true;
			}
			else 
			{
				lvlButtons [i].interactable = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
