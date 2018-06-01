using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstLaunchHandler : MonoBehaviour
{
	private DiscordController dc;
	
	// Use this for initialization
	void Start () {
		if(!PlayerPrefs.HasKey("notFirstLaunch"))
			doFirstLaunch();

		dc = GameObject.Find("DRPCHandler").GetComponent<DiscordController>();
		dc.presence.details = "In Main Menus";
		dc.presence.largeImageKey = "alejandro";
		dc.updatePresence();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void doFirstLaunch() // Insert all code for first launch of game here.
	{
		PlayerPrefs.SetFloat("gameVolume", 0.5f);
		
		PlayerPrefs.SetInt("notFirstLaunch", 1);

		SceneManager.LoadScene ("Story");
	}
}
