using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeSetter : MonoBehaviour {

	public Scrollbar slider;

	// Use this for initialization
	void Start () {
		slider = this.GetComponent<Scrollbar> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void updateVolSettings(){

		PlayerPrefs.SetFloat ("gameVolume", slider.value);
	}
}
