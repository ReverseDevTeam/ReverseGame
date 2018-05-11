using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformX : MonoBehaviour {


	[Tooltip("Speed of platform")]
	public float defaultSpeed = 2;
	private float speed;

	[Tooltip("Max distance left from original position")]
	public float distanceL;
	[Tooltip("Max distance right from original position")]
	public float distanceR;
	private float originX;
	[Tooltip("Platform stop time after turning around (in seconds)")]
	public float delayTime;
	private float delay;

	private GameObject player;
	private bool playerOn;

	void Start () {
		originX = transform.position.x;
		speed = defaultSpeed;
		player = GameObject.FindWithTag ("Player");
	}



	void Update () {
		if (transform.position.x < originX - distanceL) {					//detect max left position
			speed = 0;
			if (delay <= delayTime) {
				delay += Time.deltaTime;
			} else {
				speed = Mathf.Abs (defaultSpeed);
				delay = 0;
			}

		} else if (transform.position.x > originX + distanceR) {			//detect max right position
			speed = 0;
			if (delay <= delayTime) {
				delay += Time.deltaTime;
			} else {
				speed = -Mathf.Abs (defaultSpeed);
				delay = 0;
			}
		}
		transform.Translate (speed * Time.deltaTime, 0, 0);

	}



	void OnCollisionStay2D (Collision2D colEnter){
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
