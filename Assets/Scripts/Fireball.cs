using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	public float timer;
	public int jumpHeight;
	private float bounceTime;
	private Rigidbody2D rb;
	
	public audioControl audioCtrlScript;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		audioCtrlScript = GetComponent<audioControl>();
	}

	void Update () {
		bounceTime += Time.deltaTime;
		if (bounceTime >= timer) {
			bounceTime = 0;
			rb.AddForce (new Vector3 (0, jumpHeight, 0));
			audioCtrlScript.playSound("Fireball_noise");
		}
	}
}
