using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public Color healthColor;
	private int currHealth;

	public Text coinCount;

	void Start () {
		healthColor = GameObject.Find ("Health").GetComponent<Image> ().color;
		currHealth = PlayerPrefs.GetInt ("health");
	}

	void Update () {
		currHealth = PlayerPrefs.GetInt ("health");
		switch (currHealth) {
		case 3:
			healthColor = new Color (.2f, .6f, 1, 1);

				break;
		case 2:
			healthColor = new Color (0, 1, 0, 1);

				break;
		case 1:
			healthColor = new Color (1, 0, 0, 1);

				break;

		}
		GameObject.Find("Health").GetComponent<Image> ().color = healthColor;

		coinCount.text = PlayerPrefs.GetInt ("coins").ToString ();
	}
}
