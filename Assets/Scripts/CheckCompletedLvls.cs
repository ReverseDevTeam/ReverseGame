using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCompletedLvls : MonoBehaviour {

	public List<Button> lvlButtons = new List<Button>();

	void Start () {

		PlayerPrefs.SetInt ("lvl0_complete", 1);

		for (int i = 1; i <= 6; i++) 
		{
			lvlButtons.Add((GameObject.Find("/Canvas/fd/LevelSelect/" + i).GetComponent<Button>()));
		}

		lvlButtons[0].interactable = true;
	}

	private void Update()
	{
		for (int i = 0; i <= 5; i++) 
		{
			if (PlayerPrefs.GetInt ("lvl" + i + "_complete") == 1 || PlayerPrefs.GetInt("allLvlsUnlocked") == 1) 
			{
				if(i <= lvlButtons.Count-2)
					lvlButtons [i+1].interactable = true;
			}
			else 
			{
				switch (i)
				{
					case 0:
						break;
					default:
						lvlButtons [i].interactable = false;
						break;
				}
			}
		}
	}
}
