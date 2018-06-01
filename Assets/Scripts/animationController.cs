using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour {

	private Animator animator;

	private float scaleX;
	private float scaleY;

	private GameObject player;
	private PlayerControl ps;

	void Start () {
		animator = GetComponent<Animator>();
		scaleX = transform.localScale.x;
		scaleY = transform.localScale.y;

		player = GameObject.FindWithTag ("Player");
		ps = player.GetComponent<PlayerControl> ();
	}

	void Update () {
		gameObject.transform.localScale = new Vector3 (scaleX, scaleY, 1);
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			scaleX = Mathf.Abs (scaleX);
		}
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			scaleX = -Mathf.Abs (scaleX);
		}
			
		animator.SetBool ("Right", Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D));
		animator.SetBool ("Left", Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A));

		if (!ps.grounded) {
			animator.SetBool ("Jump", true);
		} else {
			animator.SetBool ("Jump", false);
		}
	}
}