using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardModeBtn : MonoBehaviour {

	public GameObject hardBtn;
	private int lv6;

	void Start () {
		lv6 = PlayerPrefs.GetInt ("lvl6_complete");
		if (lv6 == 1) {
			hardBtn.SetActive (true);
		} else {
			hardBtn.SetActive (false);
		}
	}
}
