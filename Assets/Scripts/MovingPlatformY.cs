using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformY : MonoBehaviour {


	[Tooltip("Speed of platform")]
	public float defaultSpeed = 2;
	private float speed;
	[Tooltip("Max distance up from original position")]
	public float distanceU;
	[Tooltip("Max distance down from original position")]
	public float distanceD;
	private float originY;
	[Tooltip("Platform stop time after turning around (in seconds)")]
	public float delayTime;
	private float delay;

	private GameObject player;
	private bool playerOn;

	void Start () {
		originY = transform.position.y;
		speed = defaultSpeed;
		player = GameObject.FindWithTag ("Player");
	}



	void Update () {
		if (transform.position.y < originY - distanceD) {					//detect max down position
			speed = 0;
			if (delay <= delayTime) {
				delay += Time.deltaTime;
			} else {
				speed = Mathf.Abs (defaultSpeed);
				delay = 0;
			}

		} else if (transform.position.y > originY + distanceU) {			//detect max up position
			speed = 0;
			if (delay <= delayTime) {
				delay += Time.deltaTime;
			} else {
				speed = -Mathf.Abs (defaultSpeed);
				delay = 0;
			}
		}
		transform.Translate (0, speed * Time.deltaTime, 0);

	}



	void OnCollisionEnter2D (Collision2D colEnter){
		if (colEnter.gameObject.name == "Player") {				//check for player on platform
			player.transform.parent = gameObject.transform;
		}
	}
	void OnCollisionExit2D (Collision2D colExit){
		if (colExit.gameObject.name == "Player") {
			player.transform.parent = null;
		}
	}
}
