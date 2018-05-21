using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour {

	Animator animator;
	Transform transform;
	public GameObject rotation180;
	public GameObject rotation0;

	void Start () {
		animator = GetComponent<Animator>();
		transform = GetComponent<Transform> ();

	}

	void Update () {
		
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			transform.rotation = rotation180.transform.rotation;
		}

		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			transform.rotation = rotation0.transform.rotation;
		}

		animator.SetBool ("Jump", Input.GetKey (KeyCode.W));
		animator.SetBool ("Backward", Input.GetKey (KeyCode.A));
		animator.SetBool ("Crouch", Input.GetKey (KeyCode.S));
		animator.SetBool ("Forward", Input.GetKey (KeyCode.D));
		animator.SetBool ("Space", Input.GetKey (KeyCode.Space));
		animator.SetBool ("JArrow", Input.GetKey (KeyCode.UpArrow));
		animator.SetBool ("BArrow", Input.GetKey (KeyCode.LeftArrow));
		animator.SetBool ("CArrow", Input.GetKey (KeyCode.DownArrow));
		animator.SetBool ("FArrow", Input.GetKey (KeyCode.RightArrow));
	}
}