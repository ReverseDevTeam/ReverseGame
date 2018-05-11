using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI : MonoBehaviour {

	public GameObject deathScr;
	public GameObject pauseScr;

	[HideInInspector]
	public bool paused;

	private GameObject player;
	private PlayerControl ps;

	void Start () {
		Time.timeScale = 1;
		deathScr = GameObject.Find ("DeathScreen");
		deathScr.SetActive (false);

		pauseScr = GameObject.Find ("PauseMenu");
		pauseScr.SetActive (false);
		paused = false;

		player = GameObject.FindWithTag ("Player");
		ps = player.GetComponent<PlayerControl> ();
	}

	void Update () {
		
		if (ps.dead == true) {
			deathScr.SetActive (true);
			Time.timeScale = 0;
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!paused && !ps.dead) {
				pauseScr.SetActive (true);
				paused = true;
				player.GetComponent<audioControl> ().enabled = false;
				Time.timeScale = 0;
			} else if (paused) {
				pauseScr.SetActive (false);
				paused = false;
				player.GetComponent<audioControl> ().enabled = true;
				Time.timeScale = 1;
			}
		}
	}

	public void setPaused(bool setPaused)
	{
		if (!setPaused) {
			pauseScr.SetActive (false);
			paused = false;
			Time.timeScale = 1;
		}
	}
}
