using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeSetter : MonoBehaviour {

	public Slider slider;

	// Use this for initialization
	void Start () {
		slider = this.GetComponent<Slider> ();
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
