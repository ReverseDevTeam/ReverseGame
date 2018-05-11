using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeUpdater : MonoBehaviour {

	public AudioSource[] audioSrc;

	// Use this for initialization
	void Start () {
		audioSrc = this.GetComponents<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		foreach (AudioSource audSrc in audioSrc) 
		{
			audSrc.volume = PlayerPrefs.GetFloat ("gameVolume");
		}
	}
}
