using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	private Rigidbody2D rb;

	public float moveSpeed = 2;
	public float jumpHeight = 400;

	public Transform groundCheck;
	public float groundCheckBox;
	public LayerMask ground;
	private bool grounded;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	public void FixedUpdate () {
		float moveH = Input.GetAxis ("Horizontal");	
		rb.velocity = new Vector2 (moveH * moveSpeed, rb.velocity.y);						//x movement


		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckBox, ground);	//check for ground
		if (Input.GetKeyDown (KeyCode.Space)) {
			rb.AddForce (new Vector2 (rb.velocity.x, jumpHeight));			   				//y movement (jumping)
		}
	}
}
