using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeSetter : MonoBehaviour {

	public Scrollbar slider;

	// Use this for initialization
	void Awake () {
		slider = this.GetComponent<Scrollbar> ();
		if (PlayerPrefs.HasKey("gameVolume"))
			slider.value = PlayerPrefs.GetFloat ("gameVolume");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateVolSettings()
	{
		PlayerPrefs.SetFloat ("gameVolume", slider.value);
	}
}
